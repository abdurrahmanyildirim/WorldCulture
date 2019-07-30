using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldCulture.Api.Dtos
{
    public class PostForCardDto
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string PostPhotoPath { get; set; }
    }
}
