using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Domain.Entities.StudentSchoolClass
{
#pragma warning disable CS8618
    public class CreditLog
    {
        public string id { get; set; }
        public float progress { get; set; }
        public float midterm { get; set; }
        public float practice { get; set; }
        public float final { get; set; }
        public float average { get; set; }

        public User user { get; set; }
        public SchoolClass schoolClass { get; set; }
    }
}
