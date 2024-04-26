using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace SchoolApi.Domain.Entities.InformationTypeGroups
{
#pragma warning disable CS8618
    public class Post
    {
        public string id { get; set; }
        public DateTime createdAt { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string fileUrlsString { get; set; }
        [NotMapped]
        public Dictionary<string, string> fileUrlsDict
        {
            get
            {
                if (fileUrlsString == null)
                    return new Dictionary<string, string>();
                return JsonSerializer.
                    Deserialize<Dictionary<string, string>>(fileUrlsString) ?? new Dictionary<string, string>();
            }
            set => fileUrlsString = JsonSerializer.Serialize(value);
        }

        //navigation here 
        public List<Faculty>? faculties { get; set; }

    }
}
