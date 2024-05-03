using SchoolApi.Infrastructure.Entities.StudentSchoolClass;
using SchoolApi.Infrastructure.Entities.UserGroups;
using System.ComponentModel.DataAnnotations;

namespace SchoolApi.API.DTOS.SchoolMember
{
#pragma warning disable CS8618
    public class LecturerUpdateRequest
    {
        [Required]
        public string id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public UserProfileRequest userProfile { get; set; }
        public IEnumerable<LecturerLogRequest> lecturerLogs { get; set; }
        public IFormFile? file { get; set; }
    }
}
