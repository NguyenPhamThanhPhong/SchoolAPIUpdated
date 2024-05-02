using SchoolApi.Infrastructure.Entities.InformationTypeGroups;
using SchoolApi.Infrastructure.Entities.SchoolClassGroups;
using SchoolApi.Infrastructure.Entities.StudentSchoolClass;

namespace SchoolApi.Infrastructure.ServiceDTOS.SchoolClassServiceDTOs
{
#pragma warning disable CS8618
    public class SchoolClassCreateServiceRequest
    {
        public string id { get; set; }
        public string name { get; set; }
        public string roomName { get; set; }
        public string program { get; set; }
        public string classType { get; set; }
        public int studentCount { get; set; }
        public int studentMax { get; set; }
        public Semester semester { get; set; }
        public Subject subject { get; set; }
        public Schedule schedule { get; set; }
        public LecturerLog lecturerLog { get; set; }
    }
}
