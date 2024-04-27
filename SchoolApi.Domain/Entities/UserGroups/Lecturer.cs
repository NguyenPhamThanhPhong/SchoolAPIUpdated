using SchoolApi.Infrastructure.Entities.StudentSchoolClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Entities.UserGroups
{
#pragma warning disable CS8618
    public class Lecturer : User
    {
        public virtual List<LecturerLog> LecturerLogs { get; set; }
    }
}
