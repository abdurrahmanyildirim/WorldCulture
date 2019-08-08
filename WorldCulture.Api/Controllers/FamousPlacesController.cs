using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldCulture.Business.Abstract;

namespace WorldCulture.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class FamousPlacesController : ControllerBase
    {
        private readonly IFamousPlaceService _famousPlaceService;

        public FamousPlacesController(IFamousPlaceService famousPlaceService)
        {
            _famousPlaceService = famousPlaceService;
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
    }
}