using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldCulture.Api.Dtos
{
    public class AccountForProfileDto
    {
        public int AccountID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonelInfo { get; set; }
        public string ProfilePhotoPath { get; set; }
    }
}
