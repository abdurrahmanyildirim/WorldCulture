using System;
using System.Collections.Generic;
using System.Text;

namespace WorldCulture.Entities.Concrete
{
   public  class Review
    {
        public int ReviewID { get; set; }
        public int DespatchID { get; set; }
        public string Name { get; set; }
        public string ReviewContent { get; set; }
        public byte Rate { get; set; }
        public DateTime ReviewDate { get; set; }

        public virtual Despatch Despatch { get; set; }
    }
}
