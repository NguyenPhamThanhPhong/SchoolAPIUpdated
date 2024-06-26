﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.ServiceDTOS
{
#pragma warning disable CS8618
    public class MultipleEntitiesResponse<TEntity> where TEntity : class
    {
        public bool IsSuccess { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<TEntity> datas { get; set; }
        public MultipleEntitiesResponse(bool IsSuccess)
        {
            this.IsSuccess = IsSuccess;
        }
    }
}
