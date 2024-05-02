using System.ComponentModel.DataAnnotations;

namespace SchoolApi.API.DTOS.Faculty
{
#pragma warning disable CS8618
    public class FacultyCreateRequest
    {
        [Required]
        public string id { get; set; }
        [Required]
        public string name { get; set; }
    }
}
