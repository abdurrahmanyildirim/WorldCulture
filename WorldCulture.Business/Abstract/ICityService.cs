using System.Collections.Generic;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.Business.Abstract
{
    public interface ICityService
    {
        List<City> GetCitiesByCountry(int countryId);
        City GetCityByID(int cityId);
        void Add(City city);
    }
}