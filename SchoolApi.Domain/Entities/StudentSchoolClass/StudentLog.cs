using SchoolApi.Domain.Entities.StudentSchoolClass;
using SchoolApi.Infrastructure.Entities.SchoolClassGroups;
using SchoolApi.Infrastructure.Entities.UserGroups;
using System.ComponentModel.DataAnnotations;


namespace SchoolApi.Infrastructure.Entities.StudentSchoolClass
{
#pragma warning disable CS8618
    public class StudentLog : SchoolmemberLog
    {
        public float progress { get; set; }
        public float midterm { get; set; }
        public float practice { get; set; }
        public float final { get; set; }
        public float average { get; set; }
        [Required]
        public virtual Student schoolMember { get; set; }
    }
}
