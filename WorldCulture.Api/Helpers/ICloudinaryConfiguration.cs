using Microsoft.AspNetCore.Http;
using WorldCulture.Api.Dtos;

namespace WorldCulture.Api.Helpers
{
    public interface ICloudinaryConfiguration
    {
        CloudinaryForReturnDto UploadImage(IFormFile file);
    }
}