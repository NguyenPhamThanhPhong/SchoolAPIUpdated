using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Domain.Entities
{
    public class User
    {
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public DateTime createdAt { get; set; }

        public UserProfile userProfile { get; set; }
        public List<SchoolClass> schoolClasses { get; set; }
        public List<ScheduleAggregation> scheduleAggregations { get; set; }

    }
}
