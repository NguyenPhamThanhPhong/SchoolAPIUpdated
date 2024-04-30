using SchoolApi.Infrastructure.Entities.UserGroups;
using System.ComponentModel.DataAnnotations;

namespace SchoolApi.API.DTOS.SchoolMember
{
#pragma warning disable CS8618
    public class LecturerUpdateRequest
    {
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        [Required]
        public UserProfileRequest userProfile { get; set; }

    }
}
