using System.ComponentModel.DataAnnotations;

namespace SchoolApi.API.DTOS.Faculty
{
    public class FacultyCreateRequest
    {
        [Required]
        public string id { get; set; }
        [Required]
        public string name { get; set; }
    }
}
