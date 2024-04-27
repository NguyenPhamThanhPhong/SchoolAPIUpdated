using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolApi.Infrastructure.Entities.SchoolClassGroups;

namespace SchoolApi.Infrastructure.Entities.InformationTypeGroups
{
    public class Semester
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public bool isDeleted { get; set; }

        public List<SchoolClass> schoolClasses { get; set; }
        public List<ScheduleTable> scheduleTables { get; set; }
        public Semester()
        {
            id= Guid.NewGuid().ToString();
            name = string.Empty;
        }
    }
}
