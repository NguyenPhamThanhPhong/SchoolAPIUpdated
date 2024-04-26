using SchoolApi.Domain.Entities.StudentSchoolClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Domain.Entities.UserGroups
{
    public class Lecturer : User
    {
        public virtual List<LecturerLog> LecturerLogs { get; set; }
    }
}
