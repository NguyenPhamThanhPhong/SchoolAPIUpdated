using SchoolApi.Infrastructure.Entities.SchoolClassGroups;
using SchoolApi.Infrastructure.Entities.UserGroups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Entities.StudentSchoolClass
{
    public class StudentLog : SchoolmemberLog
    {
        public float progress { get; set; }
        public float midterm { get; set; }
        public float practice { get; set; }
        public float final { get; set; }
        public float average { get; set; }
        [Required]
        public virtual Student schoolMember { get; set; }
        [Required]
        public virtual SchoolClass schoolClass { get; set;}
    }
}
