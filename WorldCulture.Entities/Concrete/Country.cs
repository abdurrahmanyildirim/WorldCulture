using System;
using System.Collections.Generic;
using System.Text;

namespace WorldCulture.Entities.Concrete
{
    public class Country
    {
        public Country()
        {
            Cities = new List<City>();
        }

        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string Population { get; set; }
        public string Currency { get; set; }
        public string Capital { get; set; }
        public string President { get; set; }
        public string SummaryInfo { get; set; }
        public string FlagPhotoPath { get; set; }
        public string EthnicIdentity { get; set; }
        public string Language { get; set; }
        public DateTime FoundedDate { get; set; }

        public virtual List<City> Cities { get; set; }
    }
}
