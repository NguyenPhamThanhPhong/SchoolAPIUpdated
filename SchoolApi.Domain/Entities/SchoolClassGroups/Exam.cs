using SchoolApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Entities.SchoolClassGroups
{
    public class Exam : Entity
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string room { get; set; }

        public virtual SchoolClass schoolClass { get; set; }
        public Exam()
        {
            id = Guid.NewGuid().ToString();
            name = string.Empty;
            description = string.Empty;
        }

    }
}
