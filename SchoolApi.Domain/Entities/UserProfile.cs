using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Domain.Entities
{
    public class UserProfile
    {
        public string id { get; set; }
        public string name { get; set; }
        public string avatarUrl { get; set; }
        public DateTime dateOfBirth { get; set; }
        public DateTime joinYear { get; set; }
        public string gender { get; set; }
        public string phone { get; set; }
        public string program { get; set; }


        public Faculty faculty { get; set; }
        public User user { get; set; }

    }
}
