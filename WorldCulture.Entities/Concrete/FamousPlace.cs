using System;
using System.Collections.Generic;
using System.Text;

namespace WorldCulture.Entities.Concrete
{
    public class FamousPlace
    {
        public FamousPlace()
        {
            Posts = new List<Post>();
        }

        public int FamousPlaceID { get; set; }
        public int CityID { get; set; }
        public string PlaceName { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        public bool IsActive { get; set; }

        public virtual City City { get; set; }
        public virtual List<Post> Posts { get; set; }
    }
}
