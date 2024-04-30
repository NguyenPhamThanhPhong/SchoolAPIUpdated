using SchoolApi.Infrastructure.Entities.UserGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.ServiceDTOS.LoginServiceDTOs
{
    public class LoginServiceResponse
    {
        public string refreshToken { get; set; }
        public string token { get; set; }
        public User user { get; set; }
    }
}
