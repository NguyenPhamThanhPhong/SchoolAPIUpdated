using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.API.DTOS.Semester;
using SchoolApi.Infrastructure.ServiceDTOS.SemesterServiceDTOs;
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
        [HttpPost("create")]
        public async Task<IActionResult> CreateSemester(SemesterCreateRequest request)
        {
            var serviceRequest = _mapper.Map<SemesterCreateServiceRequest>(request);
            var semester = await _semesterService.CreateSingleSemester(serviceRequest);
            return Ok(semester);
        }
        [HttpPost("create-multiple")]
        public async Task<IActionResult> CreateSemesters(IEnumerable<SemesterCreateRequest> request)
        {
            var serviceRequest = _mapper.Map<IEnumerable<SemesterCreateServiceRequest>>(request);
            var semester = await _semesterService.CreateMultipleSemesters(serviceRequest);
            return Ok(semester);
        }
        [HttpGet("{semesterId}")]
        public async Task<IActionResult> GetSemesterDetail(string semesterId)
        {
            throw new NotImplementedException();
        }
        [HttpGet("multiple/{page}")]
        public async Task<IActionResult> GetSemesters(int page)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("{semesterId}")]
        public async Task<IActionResult> DeleteSemester(string semesterId)
        {
            throw new NotImplementedException();
        }
        [HttpPost("search")]
        public async Task<IActionResult> SearchSemester(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
