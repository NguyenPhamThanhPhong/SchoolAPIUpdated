using SchoolApi.Domain.Entities;

namespace SchoolApi.Infrastructure.Entities.InformationTypeGroups
{
#pragma warning disable CS8618
    public class Faculty : Entity
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime createdAt { get; set; }

        public override bool hasOwnerShip()
            => posts.Any() && subjects.Any();


        public List<Subject> subjects { get; set; }
        public List<Post> posts { get; set; }
        public Faculty()
        {
            name =string.Empty;
            createdAt = DateTime.Now;
        }

    }
}