using SchoolApi.Domain.Entities.StudentSchoolClass;
using SchoolApi.Infrastructure.Entities.StudentSchoolClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Entities.UserGroups
{
#pragma warning disable CS8618
    public class Student : User
    {
        public virtual List<CreditLog> creditLogs { get; set; }
        public virtual List<StudentLog> studentLogs { get; set; }

    }
}
