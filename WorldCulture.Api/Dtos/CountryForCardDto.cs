using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldCulture.Api.Dtos
{
    public class CountryForCardDto
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string FlagPhotoPath { get; set; }
    }
}
