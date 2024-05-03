using Microsoft.AspNetCore.Http;

namespace SchoolApi.Infrastructure.ServiceDTOS.PostServiceDTOs
{
    public class PostUpdateServiceRequest
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public IEnumerable<string> facultyIds { get; set; }
        public IEnumerable<string> faculyIds { get; set; }
        public IEnumerable<string> keepUrls { get; set; }
        public IEnumerable<IFormFile> files { get; set; }
    }
}