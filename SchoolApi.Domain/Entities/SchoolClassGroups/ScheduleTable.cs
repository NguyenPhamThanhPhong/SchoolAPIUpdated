using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolApi.Infrastructure.Entities.InformationTypeGroups;
using SchoolApi.Infrastructure.Entities.UserGroups;

namespace SchoolApi.Infrastructure.Entities.SchoolClassGroups
{
    public class ScheduleTable
    {
        public string id { get; set; }
        public virtual Semester semester { get; set; }
        public virtual List<Schedule> schedules { get; set; }
        public virtual User User { get; set; }
        public bool isDeleted { get; set; }

        public ScheduleTable()
        {
            id = Guid.NewGuid().ToString();
        }
    }
}
