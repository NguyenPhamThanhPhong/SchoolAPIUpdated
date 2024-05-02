using SchoolApi.Infrastructure.Entities.StudentSchoolClass;
using SchoolApi.Infrastructure.Entities.UserGroups;
using System.ComponentModel.DataAnnotations;

namespace SchoolApi.API.DTOS.SchoolMember
{
    public class LecturerCreateRequest
    {
#pragma warning disable CS8618

        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public UserProfileRequest userProfile { get; set; }
        public IFormFile? file { get; set; }
    }
}
