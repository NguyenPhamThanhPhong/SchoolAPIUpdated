using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.API.DTOS.Faculty;
using SchoolApi.Infrastructure.ServiceDTOS.Base;
using SchoolApi.Infrastructure.ServiceDTOS.FacultyServiceDTOs;
using SchoolApi.Infrastructure.ServiceDTOS.SemesterServiceDTOs;
using SchoolApi.Infrastructure.Services.BusinessServices;

namespace SchoolApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyService _facultyService;
        private readonly IMapper _mapper;

        public FacultyController(IFacultyService facultyService, IMapper mapper)
        {
            _facultyService = facultyService;
            _mapper = mapper;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateSemester(FacultyCreateRequest request)
        {
            var serviceRequest = _mapper.Map<FacultyCreateServiceRequest>(request);
            var faculty = await _facultyService.CreateSingleFaculty(serviceRequest);
            return Ok(faculty);
        }
        [HttpPost("create-multiple")]
        public async Task<IActionResult> CreateFacultys(IEnumerable<FacultyCreateRequest> request)
        {
            var serviceRequest = _mapper.Map<IEnumerable<FacultyCreateServiceRequest>>(request);
            var faculties = await _facultyService.CreateMultipleFaculties(serviceRequest);
            return Ok(faculties);
        }
        [HttpGet("{facultyId}")]
        public async Task<IActionResult> GetFacultyDetail(string facultyId)
        {
            var faculty = await _facultyService.GetFacultyDetail(facultyId);
            return Ok(faculty);
        }
        [HttpGet("multiple")]
        public async Task<IActionResult> GetFacultys([FromQuery] int page, [FromQuery] int pageSize)
        {
            var faculties = await _facultyService
                .GetMultipleFaculties(new BaseGetMultipleServiceRequest(page,pageSize));
            return Ok(faculties);
        }
        [HttpDelete("{facultyId}")]
        public async Task<IActionResult> DeleteFaculty(string facultyId)
        {
            var isDeleted = await _facultyService.DeleteSingleFaculty(facultyId);
            return isDeleted ? Ok() : NotFound("not found faculty");
        }
        [HttpDelete("multiple")]
        public async Task<IActionResult> DeleteMultipleFaculties(IEnumerable<string> facultyIds)
        {
            var isDeleted = await _facultyService.DeleteMultipleFaculties(facultyIds);
            return isDeleted ? Ok() : NotFound("not found faculty");
        }

        [HttpPost("search")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> SearchFaculty([FromQuery]string searchTerm, [FromQuery] int page, [FromQuery]int pageSize=10)
        {
            var faculties = await _facultyService.SearchFaculty(
                new BaseSearchServiceRequest(searchTerm,page,pageSize));
            return Ok(faculties);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateFaculty([FromBody]FacultyUpdateRequest request)
        {
            var serviceRequest = _mapper.Map<FacultyUpdateServiceRequest>(request);
            var faculty = await _facultyService.UpdateFaculty(serviceRequest);
            return faculty==null?BadRequest():Ok(faculty);
        }
    }
}
