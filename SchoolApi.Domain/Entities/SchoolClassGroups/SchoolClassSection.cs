using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Entities.SchoolClassGroups
{
    public class SchoolClassSection
    {
        public string id { get; set; }
        public float offset { get; set;}
        public string title { get; set; }
        public string content { get; set; }
        public string fileUrlsString { get; set; }
        public bool isDeleted { get; set; }

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
        public SchoolClassSection()
        {
            id= Guid.NewGuid().ToString();
            offset= 0;
            title = string.Empty;
            content = string.Empty;
        }

    }
}
