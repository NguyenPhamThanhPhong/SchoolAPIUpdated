namespace SchoolApi.API.DTOS.Post
{
#pragma warning disable CS8618
    public class PostUpdateRequest
    {
        public string id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public IEnumerable<string>? keepUrls { get; set; }
        public IEnumerable<IFormFile>? files { get; set; }
        public PostUpdateRequest()
        {
        }
    }
}
