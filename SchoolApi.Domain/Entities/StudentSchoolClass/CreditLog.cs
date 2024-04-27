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
#pragma warning disable CS8618
    public class CreditLog
    {
        public string id { get; set; }
        public string studentId { get; set; }
        public float progress { get; set; }
        public float midterm { get; set; }
        public float practice { get; set; }
        public float final { get; set; }
        public float average { get; set; }
        public bool isDeleted { get; set; }


        [Required]
        public Student student { get; set; }
        [Required]
        public SchoolClass schoolClass { get; set; }
        public CreditLog()
        {
            id = Guid.NewGuid().ToString();
        }
    }
}
