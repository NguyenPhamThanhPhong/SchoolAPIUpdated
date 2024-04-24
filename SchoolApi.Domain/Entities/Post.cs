using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace SchoolApi.Domain.Entities
{
#pragma warning disable CS8618
    public class Post
    {
        public string id { get; set; }
        public DateTime createdAt { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public List<Faculty>? faculties { get; set; }
        [Column(TypeName = "json")]
        public string fileUrlsJson { get; set; }
        [NotMapped]
        public Dictionary<string, string> fileUrls
        {
            get
            {
                if(fileUrlsJson == null)
                    return new Dictionary<string, string>();
                return JsonSerializer.
                    Deserialize<Dictionary<string, string>>(fileUrlsJson)??new Dictionary<string, string>();
            }
            set => fileUrlsJson = JsonSerializer.Serialize(value);
        }
        public Post()
        {
            id = Guid.NewGuid().ToString();
            title = string.Empty;
            content = string.Empty;
            createdAt = DateTime.Now;
        }
    }
}
