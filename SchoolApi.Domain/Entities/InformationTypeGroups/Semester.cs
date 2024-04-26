using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolApi.Domain.Entities.SchoolClassGroups;

namespace SchoolApi.Domain.Entities.InformationTypeGroups
{
    public class Semester
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }

        public List<SchoolClass> schoolClasses { get; set; }
        public List<ScheduleTable> scheduleTables { get; set; }
    }
}
