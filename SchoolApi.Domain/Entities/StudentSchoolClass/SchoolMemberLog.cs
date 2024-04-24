using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolApi.Domain.Entities.UserGroups;

namespace SchoolApi.Domain.Entities.StudentSchoolClass
{
    public class SchoolmemberLog
    {
        public string studentId { get; set; }
        public string schoolClassId { get; set; }

        public User schoolMember { get; set; }
        public SchoolClass schoolClass { get; set; }
    }
}
