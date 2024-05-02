using Microsoft.AspNetCore.Http;
using SchoolApi.Infrastructure.Entities.StudentSchoolClass;
using SchoolApi.Infrastructure.Entities.UserGroups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.ServiceDTOS.SchoolMemberServiceDTOs
{
    public class LecturerUpdateServiceRequest
    {
#pragma warning disable CS8618
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        [Required]
        public UserProfile userProfile { get; set; }
        public IFormFile? file { get; set; }
        public List<LecturerLog> lecturerLogs { get; set; }
    }
}
