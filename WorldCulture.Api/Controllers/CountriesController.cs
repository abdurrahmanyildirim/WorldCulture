using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        private IMemoryCache _memoryCache;
        public CountriesController(ICountryService countryService,
            IMapper mapper,
            IMemoryCache memoryCache)
        {
            _countryService = countryService;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        [Route("api/countries")]
        public IActionResult GetCountries()
        {
            string key = "Countries";
            if (_memoryCache.TryGetValue(key, out List<CountryForCardDto> list))
            {
                return Ok(list);
            }
            var countries = _mapper.Map<List<CountryForCardDto>>(_countryService.GetAllCountries());

            _memoryCache.Set(key, countries, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(10),
                Priority = CacheItemPriority.Normal
            });
            return Ok(countries);
        }

        [HttpGet]
        [Route("api/country/{id}")]
        public IActionResult GetCountry(int id)
        {
            return Ok(_countryService.GetCountryById(id));
        }

        [HttpPost]
        [Route("api/country/uploadPhoto")]
        [Authorize(Roles = "Admin")]
        public IActionResult UploadPhoto([FromForm]IFormFile file)
        {
            //Todo:Profil ayarları yapıldıktan sonra burası yapılacak.
            return Ok();
        }
    }
}