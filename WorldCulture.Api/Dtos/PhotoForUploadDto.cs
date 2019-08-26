using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldCulture.Api.Dtos
{
    public class PhotoForUploadDto
    {
        public IFormFile File { get; set; }
    }
}
