using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Entities.InformationTypeGroups
{
#pragma warning disable CS8618
    public class Faculty
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime createdAt { get; set; }
        public bool isDeleted { get; set; }


        public List<Subject> subjects { get; set; }
        public List<Post> posts { get; set; }
        public Faculty()
        {
            name =string.Empty;
            createdAt = DateTime.Now;
        }

    }
}
