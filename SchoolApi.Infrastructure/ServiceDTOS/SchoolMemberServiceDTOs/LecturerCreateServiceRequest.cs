using Microsoft.AspNetCore.Http;
using SchoolApi.Infrastructure.Entities.UserGroups;
using System.ComponentModel.DataAnnotations;

namespace SchoolApi.Infrastructure.ServiceDTOS.SchoolMemberServiceDTOs
{
    public class LecturerCreateServiceRequest
    {
#pragma warning disable CS8618
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }

        [Required]
        public UserProfile userProfile { get; set; }
        public IFormFile? file { get; set; }

        public LecturerCreateServiceRequest()
        {
            id = Guid.NewGuid().ToString();
            userProfile = new UserProfile();
            userProfile.userId = id;
        }
    }
}