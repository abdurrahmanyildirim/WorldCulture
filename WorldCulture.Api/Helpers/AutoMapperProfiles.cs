using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldCulture.Api.Dtos;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Country, CountryForCardDto>();
            CreateMap<City, CityForCardDto>();
            CreateMap<Post, PostForCardDto>();
            CreateMap<Account, AccountForProfileDto>();
        }
    }
}
