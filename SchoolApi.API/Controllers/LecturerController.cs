using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.API.DTOS.SchoolMember;
using SchoolApi.Infrastructure.ServiceDTOS.Base;
using SchoolApi.Infrastructure.ServiceDTOS.SchoolMemberServiceDTOs;
using SchoolApi.Infrastructure.Services.BusinessServices;

namespace SchoolApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturerController : ControllerBase
    {
        private readonly ILecturerService _lecturerService;
        private readonly IMapper _mapper;

        public LecturerController(ILecturerService lecturerService, IMapper mapper)
        {
            _lecturerService = lecturerService;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateLecturer(LecturerCreateRequest request)
        {
            var serviceRequest = _mapper.Map<LecturerCreateServiceRequest>(request);
            var lecturer = await _lecturerService.CreateSingleLecturer(serviceRequest);
            return Ok(lecturer);
        }
        [HttpPost("create-multiple")]
        public async Task<IActionResult> CreateMultipleLecturers(List<LecturerCreateRequest> request)
        {
            var serviceRequest = _mapper.Map<List<LecturerCreateServiceRequest>>(request);
            var lecturers = await _lecturerService.CreateMultipleLecturers(serviceRequest);
            return Ok(lecturers);
        }
        [HttpGet("multiple/{page}")]
        public async Task<IActionResult> GetMultipleLecturers([FromQuery] int page, [FromQuery] int pageSize)
        {
            var lecturers = await _lecturerService.GetMultipleLecturers(new BaseGetMultipleServiceRequest(page,pageSize));
            return Ok(lecturers);
        }
        [HttpGet("{lecturerId}")]
        public async Task<IActionResult> GetLecturerDetail(string lecturerId)
        {
            var lecturer = await _lecturerService.GetLecturerDetail(lecturerId);
            return Ok(lecturer);
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchLecturer([FromQuery] string searchTerm, [FromQuery]int page, [FromQuery]int pageSize)
        {
            var lecturers = await _lecturerService.SearchLecturer(new BaseSearchServiceRequest(searchTerm,page,pageSize) );
            return Ok(lecturers);
        }
        [HttpDelete("{lecturerId}")]
        public async Task<IActionResult> DeleteLecturer(string lecturerId)
        {
            var isDeleted = await _lecturerService.DeleteSingleLecturer(lecturerId);
            return isDeleted ? Ok() : NotFound("not found lecturer");
        }

        [HttpDelete("multiple")]
        public async Task<IActionResult> DeleteLecturers([FromQuery] List<string> lecturerIds)
        {
            var isDeleted = await _lecturerService.DeleteMultipleLecturers(lecturerIds);
            return isDeleted ? Ok() : NotFound("not found lecturer");
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateLecturer([FromBody] LecturerUpdateRequest request)
        {
            var serviceRequest = _mapper.Map<LecturerUpdateServiceRequest>(request);
            var isUpdated = await _lecturerService.UpdateLecturer(serviceRequest);
            return isUpdated==null ? Ok() : NotFound("not found lecturer");
        }


    }
}
