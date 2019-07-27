using System;
using System.Collections.Generic;
using System.Text;

namespace WorldCulture.Entities.Concrete
{
    public class Despatch
    {
        public Despatch()
        {
            Reviews = new List<Review>();
        }

        public int DespatchID { get; set; }
        public int FamousPlaceID { get; set; }
        public int AccountID { get; set; }
        public string Title { get; set; }
        public string DespatchPhotoPath { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte Rate { get; set; }

        public FamousPlace FamousPlace { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
