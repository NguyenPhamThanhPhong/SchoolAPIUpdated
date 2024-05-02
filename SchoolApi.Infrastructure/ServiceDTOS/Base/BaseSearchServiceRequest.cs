﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.ServiceDTOS.Base
{
    public class BaseSearchServiceRequest
    {
        public string searchTerm { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public BaseSearchServiceRequest(string searchTerm="",int page = 0, int pageSize=10)
        {
            this.searchTerm = searchTerm;
            this.page = page;
            this.pageSize = pageSize;
        }
    }
}