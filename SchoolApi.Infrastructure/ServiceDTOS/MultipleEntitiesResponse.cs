using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.ServiceDTOS
{
    public class MultipleEntitiesResponse<TEntity> where TEntity : class
    {
        public bool Success { get; set; }
        public string Message { get; set; } 
        public int TotalCount { get; set; }
        public IEnumerable<TEntity> datas { get; set; }
    }
}
