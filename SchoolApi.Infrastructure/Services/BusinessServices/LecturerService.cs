using SchoolApi.Infrastructure.Entities.InformationTypeGroups;
using SchoolApi.Infrastructure.ServiceDTOS.SemesterServiceDTOs;
using SchoolApi.Infrastructure.ServiceDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolApi.Infrastructure.Entities.UserGroups;
using SchoolApi.Infrastructure.ServiceDTOS.SchoolMemberServiceDTOs;

namespace SchoolApi.Infrastructure.Services.BusinessServices
{
    public interface ILecturerService
    {
        public Task<Lecturer> CreateSingleLecturer(LecturerCreateServiceRequest request);
        public Task<IEnumerable<Lecturer>> CreateMultipleLecturers(IEnumerable<LecturerCreateServiceRequest> requests);
        public Task<Lecturer> GetLecturerDetail(string lecturerId);
        public Task<MultipleEntitiesResponse<Lecturer>> GetMultipleLecturers(int page);
        public Task<bool> DeleteSingleLecturer(string lecturerId);
        public Task<bool> DeleteMultipleLecturers(IEnumerable<string> lecturerIds);
        public Task<MultipleEntitiesResponse<Lecturer>> SearchLecturer(string searchTerm);
        public Task<bool> UpdateLecturer(LecturerUpdateServiceRequest request);
    }
    public class LecturerService
    {
    }
}
