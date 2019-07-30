using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldCulture.Api.Dtos
{
    public class CityForCardDto
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string CityPhotoPath { get; set; }
    }
}
