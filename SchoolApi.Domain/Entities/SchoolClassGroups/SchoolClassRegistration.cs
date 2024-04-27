using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolApi.Infrastructure.Entities.InformationTypeGroups;

namespace SchoolApi.Infrastructure.Entities.SchoolClassGroups
{
#pragma warning disable CS8618
    public class SchoolClassRegistration
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public Semester semester { get; set; }
        public List<SchoolClass> schoolClasses { get; set; }
        public bool isDeleted { get; set; }

        public SchoolClassRegistration()
        {
            id = Guid.NewGuid().ToString();
            name = string.Empty;
        }

    }
}