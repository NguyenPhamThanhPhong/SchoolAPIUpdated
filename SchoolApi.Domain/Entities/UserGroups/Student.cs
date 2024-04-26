using SchoolApi.Domain.Entities.StudentSchoolClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Domain.Entities.UserGroups
{
    public class Student : User
    {
        public virtual List<CreditLog> creditLogs { get; set; }
        public virtual List<StudentLog> studentLogs { get; set; }

    }
}
