using System;
using System.Collections.Generic;
using System.Text;

namespace WorldCulture.Entities.Concrete
{
    public class City
    {
        public City()
        {
            FamousPlaces = new List<FamousPlace>();
        }

        public int CityID { get; set; }
        public int CountryID { get; set; }
        public string CityName { get; set; }
        public string Population { get; set; }
        public string Description { get; set; }
        public string CityPhotoPath { get; set; }
        public string PublicId { get; set; }

        public virtual Country Country { get; set; }
        public virtual List<FamousPlace> FamousPlaces { get; set; }
    }
}
