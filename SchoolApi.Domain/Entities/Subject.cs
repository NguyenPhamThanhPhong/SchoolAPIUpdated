using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Domain.Entities
{
    public class Subject
    {
#pragma warning disable CS8618
        public string id { get; set; }
        public string name { get; set; }

        public List<Subject> previousSubjects { get; set; }
        public List<Subject> prequisiteSubjects { get; set;}
        public Faculty faculty { get; set; }
        public List<SchoolClass> classes { get; set; }
        public Subject()
        {
            id = Guid.NewGuid().ToString();
        }
    }
}
