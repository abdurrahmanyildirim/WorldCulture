using System.Collections.Generic;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.Business.Abstract
{
    public interface ICountryService
    {
        List<Country> GetAllCountries();
        Country GetCountryById(int id);
        void Add(Country country);
    }
}