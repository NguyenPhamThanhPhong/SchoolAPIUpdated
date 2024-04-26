using SchoolApi.Domain.Entities.InformationTypeGroups;
using SchoolApi.Domain.Entities.StudentSchoolClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Domain.Entities.SchoolClassGroups
{
    public class SchoolClass
    {
        public string id { get; set; }
        public string name { get; set; }
        public string roomName { get; set; }
        public string program { get; set; }
        public string classType { get; set; }

        public virtual Semester semester { get; set; }
        public virtual Subject subject { get; set; }
        public virtual Schedule schedule { get; set; }
        public virtual LecturerLog lecturerLog { get; set; }
        public virtual List<StudentLog> studentLogs { get; set; }
        public virtual List<CreditLog> creditLogs { get; set; }
        public virtual List<Exam> exams { get; set; }
        public virtual List<SchoolClassSection> sections { get; set; }
    }
}
