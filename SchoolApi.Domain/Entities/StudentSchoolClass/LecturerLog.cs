using SchoolApi.Infrastructure.Entities.UserGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Entities.StudentSchoolClass
{
    public class LecturerLog : SchoolmemberLog
    {
        public virtual Lecturer schoolMember { get; set; }
    }
}
