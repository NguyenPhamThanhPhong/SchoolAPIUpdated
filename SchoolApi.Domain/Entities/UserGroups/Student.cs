using SchoolApi.Domain.Entities.StudentSchoolClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Domain.Entities.UserGroups
{
    public class Student
    {
        public virtual List<CreditLog> credits { get; set; }

    }
}
