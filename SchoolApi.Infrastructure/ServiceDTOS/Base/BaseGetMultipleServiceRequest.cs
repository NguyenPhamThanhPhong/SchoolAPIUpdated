using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.ServiceDTOS.Base
{
    public class BaseGetMultipleServiceRequest
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public BaseGetMultipleServiceRequest(int page=0,int pageSize=10)
        {
            this.page = page;
            this.pageSize = pageSize;
        }
    }
}
