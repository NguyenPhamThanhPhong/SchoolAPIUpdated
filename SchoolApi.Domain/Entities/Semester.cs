using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Domain.Entities
{
    public class Semester
    {
        public string id { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public List<SchoolClass>? classes { get; set; }
        public Semester() 
        { 
            id = Guid.NewGuid().ToString();
            classes = new List<SchoolClass>();

        }
    }
}
