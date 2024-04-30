using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.API.DTOS.SchoolMember;
using SchoolApi.Infrastructure.ServiceDTOS.SchoolMemberServiceDTOs;
using SchoolApi.Infrastructure.Services.BusinessServices;

namespace SchoolApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateStudent(StudentCreateRequest request)
        {
            var serviceRequest = _mapper.Map<StudentCreateServiceRequest>(request);
            var student = await _studentService.CreateSingleStudent(serviceRequest);
            return Ok(student);
        }
        [HttpPost("create-multiple")]
        public async Task<IActionResult> CreateStudents(List<StudentCreateRequest> request)
        {
            var serviceRequest = _mapper.Map<List<StudentCreateServiceRequest>>(request);
            var students = await _studentService.CreateMultipleStudents(serviceRequest);
            return Ok(students);
        }
        [HttpGet("multiple/{page}")]
        public async Task<IActionResult> GetMultipleStudents(int page)
        {
            var students = await _studentService.GetMultipleStudents(page);
            return Ok(students);
        }
        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudentDetail(string studentId)
        {
            var student = await _studentService.GetStudentDetail(studentId);
            return Ok(student);
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchStudent([FromQuery] string searchTerm)
        {
            var students = await _studentService.SearchStudent(searchTerm);
            return Ok(students);
        }
        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudent(string studentId)
        {
            var isDeleted = await _studentService.DeleteSingleStudent(studentId);
            return isDeleted ? Ok() : NotFound("not found student");
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateStudent(StudentUpdateRequest request)
        {
            var serviceRequest = _mapper.Map<StudentUpdateServiceRequest>(request);
            var student = await _studentService.UpdateStudent(serviceRequest);
            return Ok(student);
        }
    }
}
