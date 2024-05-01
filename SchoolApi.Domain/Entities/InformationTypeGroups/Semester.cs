using SchoolApi.Domain.Entities;
using SchoolApi.Infrastructure.Entities.SchoolClassGroups;

namespace SchoolApi.Infrastructure.Entities.InformationTypeGroups
{
#pragma warning disable CS8618
    public class Semester : Entity
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }


        public virtual List<SchoolClass> schoolClasses { get; set; }
        public virtual List<ScheduleTable> scheduleTables { get; set; }
        public Semester()
        {
            id= Guid.NewGuid().ToString();
            name = string.Empty;
        }
    }
}