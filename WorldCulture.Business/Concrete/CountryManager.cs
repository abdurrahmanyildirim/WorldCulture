using System;
using System.Collections.Generic;
using System.Text;
using WorldCulture.Business.Abstract;
using WorldCulture.DataAccess.Abstract;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.Business.Concrete
{
    public class CountryManager : ICountryService
    {
        private ICountryDal _countryDal;

        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }

        public List<Country> GetAllCountries()
        {
            return _countryDal.GetAll();
        }

        public Country GetCountryById(int id)
        {
            return _countryDal.Get(x=>x.CountryID==id);
        }

        public void Add(Country country)
        {
            _countryDal.Add(country);
        }
    }
}
