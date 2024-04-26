using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SchoolApi.Domain.Entities.SchoolClassGroups
{
    public class SchoolClassSection
    {
        public string id { get; set; }
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

    }
}
