using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldCulture.Api.Dtos
{
    public class AccountForChangePasswordDto
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
