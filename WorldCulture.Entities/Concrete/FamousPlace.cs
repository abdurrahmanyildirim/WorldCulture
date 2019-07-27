using System;
using System.Collections.Generic;
using System.Text;

namespace WorldCulture.Entities.Concrete
{
    public class FamousPlace
    {
        public FamousPlace()
        {
            Despatches = new List<Despatch>();
        }

        public int FamousPlaceID { get; set; }
        public int CityID { get; set; }
        public string PlaceName { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }

        public City City { get; set; }
        public List<Despatch> Despatches { get; set; }
    }
}
