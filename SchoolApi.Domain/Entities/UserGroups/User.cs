using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolApi.Domain.Entities;
using SchoolApi.Infrastructure.Entities.SchoolClassGroups;
using SchoolApi.Infrastructure.Entities.StudentSchoolClass;

namespace SchoolApi.Infrastructure.Entities.UserGroups
{
#pragma warning disable CS8618
    public class User : Entity
    {
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public string role { get; set; }
        public DateTime createdAt { get; set; }

        [Required]
        public UserProfile userProfile { get; set; }
        public virtual List<ScheduleTable> scheduleTables { get; set; }

    }
}
