namespace SchoolApi.API.DTOS.Post
{
#pragma warning disable CS8618
    public class PostCreateRequest
    {
        public string title { get; set; }
        public string content { get; set; }
        public IEnumerable<IFormFile>? files { get; set; }
    }
}
