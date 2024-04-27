using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Configurations
{
#pragma warning disable CS8618
    public class SMTPConfigs
    {
        public string SMTPServer { get; set; }
        public string Port { get; set; }
        public string SecurityChoice { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FromEmail { get; set; }
    }
}
