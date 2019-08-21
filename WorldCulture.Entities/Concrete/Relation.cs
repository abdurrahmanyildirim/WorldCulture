using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WorldCulture.Entities.Concrete
{
    public class Relation
    {
        public Relation()
        {
            Date = DateTime.Now;
        }
        public int RelationID { get; set; }
        public int FromAccountID { get; set; }
        public int? ToAccountID { get; set; }
        public DateTime Date { get; set; }

        public virtual Account FromAccount { get; set; }
        public virtual Account ToAccount { get; set; }
    }
}
