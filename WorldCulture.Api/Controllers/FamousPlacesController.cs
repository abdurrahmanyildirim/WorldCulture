using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldCulture.Api.Dtos;
using WorldCulture.Api.Helpers;
using WorldCulture.Business.Abstract;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class FamousPlacesController : ControllerBase
    {
        private readonly IFamousPlaceService _famousPlaceService;
        private readonly ICloudinaryConfiguration _cloudinaryConfiguration;

        public FamousPlacesController(IFamousPlaceService famousPlaceService,
            ICloudinaryConfiguration cloudinaryConfiguration)
        {
            _famousPlaceService = famousPlaceService;
            _cloudinaryConfiguration = cloudinaryConfiguration;
        }

        [HttpGet]
        [Route("api/places/{id}")]
        public IActionResult GetPlacesByCity(int id = 0)
        {
            if (id == 0)
                return BadRequest();

            return Ok(_famousPlaceService.GetPlacesByCity(id));
        }

        [HttpGet]
        [Route("api/place/{id}")]
        public IActionResult GetPlaceByID(int id = 0)
        {
            if (id == 0)
                return BadRequest();

            return Ok(_famousPlaceService.GetPlaceByID(id));
        }

        [HttpPost]
        [Route("api/place/upload-photo")]
        [Authorize(Roles = "Admin")]
        public IActionResult UploadPhoto([FromForm]PhotoForUploadDto photo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Hatalı model gönderimi!");
            }

            var file = photo.File;
            CloudinaryForReturnDto cloudinary = _cloudinaryConfiguration.UploadImage(file);
            return Ok(new PhotoForReturnDto { PhotoPath = cloudinary.Url, PublicId = cloudinary.PublicId });
        }

        [HttpPost]
        [Route("api/place/add-place")]
        [Authorize(Roles = "Admin")]
        public IActionResult Add([FromBody]FamousPlace famousPlace)
        {
            try
            {
                _famousPlaceService.Add(famousPlace);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}