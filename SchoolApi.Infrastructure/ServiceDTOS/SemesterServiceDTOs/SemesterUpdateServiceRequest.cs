using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.ServiceDTOS.SemesterServiceDTOs
{
    public class SemesterUpdateServiceRequest
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public SemesterUpdateServiceRequest()
        {
            id = string.Empty;
            name = string.Empty;
        }
    }
}
