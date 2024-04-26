using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolApi.Domain.Entities.InformationTypeGroups;
using SchoolApi.Domain.Entities.UserGroups;

namespace SchoolApi.Domain.Entities.SchoolClassGroups
{
    public class ScheduleTable
    {
        public string id { get; set; }
        public virtual Semester semester { get; set; }
        public virtual List<Schedule> schedules { get; set; }
        public virtual User User { get; set; }
    }
}
