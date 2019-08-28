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
        public DateTime MemberDate { get; set; }
        public string Followers { get; set; }
        public string Followings { get; set; }
    }
}
