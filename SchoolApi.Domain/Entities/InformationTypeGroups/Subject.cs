using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolApi.Domain.Entities.SchoolClassGroups;

namespace SchoolApi.Domain.Entities.InformationTypeGroups
{
    public class Subject
    {
#pragma warning disable CS8618
        public string id { get; set; }
        public string name { get; set; }

        public virtual List<Subject> previousSubjects { get; set; }
        public virtual List<Subject> prequisiteSubjects { get; set; }
        public virtual List<SchoolClass> schoolClasses { get; set; }
        public virtual Faculty faculty { get; set; }
    }
}
