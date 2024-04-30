using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolApi.Domain.Entities;
using SchoolApi.Infrastructure.Entities.InformationTypeGroups;

namespace SchoolApi.Infrastructure.Entities.SchoolClassGroups
{
#pragma warning disable CS8618
    public class SchoolClassRegistration : Entity
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public Semester semester { get; set; }
        public List<SchoolClass> schoolClasses { get; set; }
        public SchoolClassRegistration()
        {
            id = Guid.NewGuid().ToString();
            name = string.Empty;
        }

    }
}