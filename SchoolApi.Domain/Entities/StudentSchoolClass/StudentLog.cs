using SchoolApi.Domain.Entities.SchoolClassGroups;
using SchoolApi.Domain.Entities.UserGroups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public virtual Student schoolMember { get; set; }
        [Required]
        public virtual SchoolClass schoolClass { get; set;}
    }
}
