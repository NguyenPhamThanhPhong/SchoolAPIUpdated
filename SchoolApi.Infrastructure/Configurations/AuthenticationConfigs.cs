using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Configurations
{
    public class AuthenticationConfigs
    {
#pragma warning disable CS8618

        public string AccessTokenSecret { get; set; }
        public string RefreshTokenSecret { get; set; }
        public int AccessTokenExpirationMinutes { get; set; }
        public int RefreshTokenExpirationMinutes { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
