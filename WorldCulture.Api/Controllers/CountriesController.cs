using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WorldCulture.Api.Dtos;
using WorldCulture.Api.Helpers;
using WorldCulture.Business.Abstract;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private IMapper _mapper;
        private IMemoryCache _memoryCache;
        private readonly ICloudinaryConfiguration _cloudinaryConfiguration;

        public CountriesController(ICountryService countryService,
            IMapper mapper,
            IMemoryCache memoryCache,
            ICloudinaryConfiguration cloudinaryConfiguration)
        {
            _countryService = countryService;
            _mapper = mapper;
            _memoryCache = memoryCache;
            _cloudinaryConfiguration = cloudinaryConfiguration;
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
                AbsoluteExpiration = DateTime.Now.AddMinutes(30),
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
        [Route("api/country/upload-photo")]
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
        [Route("api/country/add-country")]
        [Authorize(Roles = "Admin")]
        public IActionResult Add([FromBody]Country country)
        {
            try
            {
                _countryService.Add(country);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}