using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Infrastructure.Services.BusinessServices;

namespace SchoolApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolClassController : ControllerBase
    {
        private readonly ISchoolClassService _schoolClassService;
        private readonly IMapper _mapper;

        public SchoolClassController(ISchoolClassService schoolClassService, IMapper mapper)
        {
            _schoolClassService = schoolClassService;
            _mapper = mapper;
        }
    }
}
