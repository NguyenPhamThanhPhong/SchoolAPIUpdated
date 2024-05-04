using SchoolApi.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApi.Infrastructure.Entities.InformationTypeGroups
{
#pragma warning disable CS8618
    public class Faculty : Entity
    {
        public string id { get; set; }
        public string name { get; set; }
        [ForeignKey("subjects")]
        public IEnumerable<string> subjectIds { get; set; }
        [ForeignKey("posts")]
        public IEnumerable<string> postIds { get; set; }

        public virtual List<Subject> subjects { get; set; }
        public virtual List<Post> posts { get; set; }
        public Faculty()
        {
            name =string.Empty;
        }

    }
}