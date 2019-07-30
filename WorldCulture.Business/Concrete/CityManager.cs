using System;
using System.Collections.Generic;
using System.Text;
using WorldCulture.Business.Abstract;
using WorldCulture.DataAccess.Abstract;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.Business.Concrete
{
    public class CityManager : ICityService
    {
        private ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public List<City> GetCitiesByCountry(int countryId)
        {
            return _cityDal.GetAll(x => x.CountryID == countryId);
        }

        public City GetCityByID(int cityId)
        {
            return _cityDal.Get(x => x.CityID == cityId);
        }
    }
}
