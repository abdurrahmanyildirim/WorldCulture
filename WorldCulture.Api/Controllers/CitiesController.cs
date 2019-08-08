using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldCulture.Api.Dtos;
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

        public CitiesController(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
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
    }
}