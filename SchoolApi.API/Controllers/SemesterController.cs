using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.API.DTOS;
using SchoolApi.Infrastructure.ServiceDTOS.Semester;
using SchoolApi.Infrastructure.Services.BusinessServices;

namespace SchoolApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        private readonly ISemesterService _semesterService;
        private readonly IMapper _mapper;
        public SemesterController(ISemesterService semesterService, IMapper mapper)
        {
            _semesterService = semesterService;
            _mapper = mapper;
        }
        [HttpPost("")]
        public async Task<IActionResult> CreateSemester(SemesterCreateRequest request)
        {
            var serviceRequest = _mapper.Map<SemesterCreateServiceRequest>(request);
            var semester = await _semesterService.CreateSemester(serviceRequest);
            return Ok(semester);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSemesterDetail(string id)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSemester(string id)
        {
            throw new NotImplementedException();

        }
    }
}
