using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Domain.Entities.SchoolClassGroups
{
    public class Schedule
    {
#pragma warning disable CS8618
        public string id { get; set; }
        public string schoolClassId { get; set; }
        public string room { get; set; }
        public string description { get; set; }
        public DayOfWeek dayOfWeek { get; set; }
        public TimeSpan start { get; set; }
        public TimeSpan end { get; set; }

        public virtual ScheduleTable scheduleTable { get; set; }
        public virtual SchoolClass schoolClass { get; set; }
    }
    public enum DayOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
}

