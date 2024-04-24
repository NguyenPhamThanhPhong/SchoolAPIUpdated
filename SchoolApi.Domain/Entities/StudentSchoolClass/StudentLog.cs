using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Domain.Entities.StudentSchoolClass
{
    public class StudentLog : SchoolmemberLog
    {
        public int progress { get; set; }
        public int midterm { get; set; }
        public int practice { get; set; }
        public int final { get; set; }
        public int average { get; set; }
    }
}
