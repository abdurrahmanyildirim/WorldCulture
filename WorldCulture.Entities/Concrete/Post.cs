using System;
using System.Collections.Generic;
using System.Text;

namespace WorldCulture.Entities.Concrete
{
    public class Post
    {
        public Post()
        {
            Reviews = new List<Review>();
        }

        public int PostID { get; set; }
        public int FamousPlaceID { get; set; }
        public int AccountID { get; set; }
        public string Title { get; set; }
        public string PostPhotoPath { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte Rate { get; set; }
        public string CountOfView { get; set; }

        public virtual FamousPlace FamousPlace { get; set; }
        public virtual List<Review> Reviews { get; set; }
    }
}
