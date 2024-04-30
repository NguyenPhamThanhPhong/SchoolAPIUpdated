using SchoolApi.Infrastructure.ServiceDTOS.LoginServiceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Services.BusinessServices
{
    public interface ILoginService
    {
        public Task<LoginServiceResponse> Login(LoginServiceRequest request);
        public Task<string> RefreshToken(string refreshToken);
    }
    public class LoginService
    {
    }
}
