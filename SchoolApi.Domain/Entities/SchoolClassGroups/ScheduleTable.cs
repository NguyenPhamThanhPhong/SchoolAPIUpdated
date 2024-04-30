using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolApi.Domain.Entities;
using SchoolApi.Infrastructure.Entities.InformationTypeGroups;
using SchoolApi.Infrastructure.Entities.UserGroups;

namespace SchoolApi.Infrastructure.Entities.SchoolClassGroups
{
    public class ScheduleTable : Entity
    {
        public string id { get; set; }
        public virtual Semester semester { get; set; }
        public virtual List<Schedule> schedules { get; set; }
        public virtual User user { get; set; }

        public ScheduleTable()
        {
            id = Guid.NewGuid().ToString();
        }
    }
}
