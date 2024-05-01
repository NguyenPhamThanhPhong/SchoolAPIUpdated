using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.ServiceDTOS.FacultyServiceDTOS
{
    public class FacultySearchServiceRequest
    {
        public string searchTerm { get; set; }
        public int page { get; set; }
    }
}
