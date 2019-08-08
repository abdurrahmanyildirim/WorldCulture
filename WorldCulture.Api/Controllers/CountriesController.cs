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

namespace WorldCulture.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private IMapper _mapper;
        public CountriesController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/countries")]
        public IActionResult GetCountries()
        {
            var countries = _mapper.Map<List<CountryForCardDto>>(_countryService.GetAllCountries());
            return Ok(countries);
        }

        [HttpGet]
        [Route("api/country/{id}")]
        public IActionResult GetCountry(int id)
        {
            return Ok(_countryService.GetCountryById(id));
        }
    }
}