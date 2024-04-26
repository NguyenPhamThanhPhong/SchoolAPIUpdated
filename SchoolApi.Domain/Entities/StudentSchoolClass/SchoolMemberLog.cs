using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolApi.Domain.Entities.SchoolClassGroups;
using SchoolApi.Domain.Entities.UserGroups;

namespace SchoolApi.Domain.Entities.StudentSchoolClass
{
    public abstract class SchoolmemberLog
    {
        [Key]
        [Column(Order =1)]
        public string schoolMemberId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string schoolClassId { get; set; }

        [Required]
        public virtual SchoolClass schoolClass { get; set; }
    }
}
