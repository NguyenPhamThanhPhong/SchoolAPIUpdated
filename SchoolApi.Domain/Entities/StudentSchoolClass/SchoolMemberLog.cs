using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolApi.Domain.Entities;
using SchoolApi.Infrastructure.Entities.SchoolClassGroups;
using SchoolApi.Infrastructure.Entities.UserGroups;

namespace SchoolApi.Infrastructure.Entities.StudentSchoolClass
{
    //[PrimaryKey(nameof(schoolMemberId), nameof(schoolClassId))]
#pragma warning disable CS8618
    public abstract class SchoolmemberLog : Entity
    {
        [Column(Order =1)]
        public string schoolMemberId { get; set; }
        [Column(Order = 2)]
        public string schoolClassId { get; set; }

        [Required]
        public virtual SchoolClass schoolClass { get; set; }
    }
}
