using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldCulture.Api.Dtos
{
    public class PhotoForCreationDto
    {
        public IFormFile File { get; set; }
    }
}
