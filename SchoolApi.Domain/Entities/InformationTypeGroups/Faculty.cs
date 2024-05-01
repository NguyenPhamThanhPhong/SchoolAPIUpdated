using SchoolApi.Domain.Entities;

namespace SchoolApi.Infrastructure.Entities.InformationTypeGroups
{
#pragma warning disable CS8618
    public class Faculty : Entity
    {
        public string id { get; set; }
        public string name { get; set; }

        public virtual List<Subject> subjects { get; set; }
        public virtual List<Post> posts { get; set; }
        public Faculty()
        {
            name =string.Empty;
        }

    }
}