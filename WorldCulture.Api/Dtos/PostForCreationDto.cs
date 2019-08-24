
namespace WorldCulture.Api.Dtos
{
    public class PostForCreationDto
    {
        public int AccountID { get; set; }
        public int FamousPlaceID { get; set; }
        public string PostPhotoPath { get; set; }
        public string PublicId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
