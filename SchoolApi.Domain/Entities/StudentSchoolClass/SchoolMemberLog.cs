using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolApi.Domain.Entities;
using SchoolApi.Infrastructure.Entities.SchoolClassGroups;
using SchoolApi.Infrastructure.Entities.UserGroups;

namespace SchoolApi.Infrastructure.Entities.StudentSchoolClass
{
    public abstract class SchoolmemberLog : Entity
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
