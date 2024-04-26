using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolApi.Domain.Entities.InformationTypeGroups;

namespace SchoolApi.Domain.Entities.UserGroups
{
    public class UserProfile
    {
        [Key]
        public string userId { get; set; }
        public string name { get; set; }
        public string avatarUrl { get; set; }
        public DateTime dateOfBirth { get; set; }
        public DateTime joinYear { get; set; }
        public string gender { get; set; }
        public string phone { get; set; }
        public string program { get; set; }
    }
}
