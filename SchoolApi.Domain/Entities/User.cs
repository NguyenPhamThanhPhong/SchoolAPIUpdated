using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Domain.Entities
{
#pragma warning disable CS8618
    public class User
    {
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string role { get; set; }

        public UserProfile userProfile { get; set; }
        public List<SchoolClass> classes { get; set; }
        public List<Schedule> scheduleAggregations { get; set; }
        public List<Credit>? credits { get; set; }

    }
}
