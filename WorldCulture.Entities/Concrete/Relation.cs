using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WorldCulture.Entities.Concrete
{
    public class Relation
    {
        public int RelationID { get; set; }
        [ForeignKey("FromAccount")]
        public int FromAccountID { get; set; }
        [ForeignKey("ToAccount")]
        public int ToAccountID { get; set; }
        public DateTime Date { get; set; }

        public Account FromAccount { get; set; }
        public Account ToAccount { get; set; }
    }
}
