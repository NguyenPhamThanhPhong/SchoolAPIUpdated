using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Domain.Entities
{
    public class ScheduleTable
    {
        public string id { get; set; }
        public virtual Semester semester { get; set; }
        public virtual Schedule schedule { get; set; }
    }
}
