using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;
        private readonly ICloudinaryConfiguration _cloudinaryConfiguration;

        public CitiesController(ICityService cityService,
            IMapper mapper,
            ICloudinaryConfiguration cloudinaryConfiguration)
        {
            _cityService = cityService;
            _mapper = mapper;
            _cloudinaryConfiguration = cloudinaryConfiguration;
        }

        [HttpGet]
        [Route("api/cities/{id}")]
        public IActionResult GetCitiesByCountry(int id = 0)
        {
            if(id==0)
                return BadRequest("Böyle bir ülke bulunmamaktadır."); 

            var cities = _mapper.Map<List<CityForCardDto>>(_cityService.GetCitiesByCountry(id));

            if (cities == null)
                return BadRequest("Ülke id'si geçersiz.");

            return Ok(cities);
        }

        [HttpGet]
        [Route("api/city/{id}")]
        public IActionResult GetCityByID(int id)
        {
            return Ok(_cityService.GetCityByID(id));
        }

        [HttpPost]
        [Route("api/city/upload-photo")]
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
        [Route("api/city/add-city")]
        [Authorize(Roles = "Admin")]
        public IActionResult Add([FromBody]City city)
        {
            try
            {
                _cityService.Add(city);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}