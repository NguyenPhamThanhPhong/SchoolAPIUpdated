using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolApi.Domain.Entities.StudentSchoolClass;

namespace SchoolApi.Domain.Entities.UserGroups
{
#pragma warning disable CS8618
    public class User
    {
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public DateTime createdAt { get; set; }

        public UserProfile userProfile { get; set; }
        public virtual SchoolmemberLog lecturer { get; set; }
        public virtual List<SchoolmemberLog> studentLogs { get; set; }
        public virtual List<ScheduleTable> scheduleTables { get; set; }
    }
}
