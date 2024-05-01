using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Domain.Entities
{
    public class Entity
    {
        public bool isDeleted { get; set; }
        public DateTime createdAt { get; set; }
    }
}
