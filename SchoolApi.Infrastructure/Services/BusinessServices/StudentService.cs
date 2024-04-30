using SchoolApi.Infrastructure.ServiceDTOS;
using SchoolApi.Infrastructure.ServiceDTOS.SchoolMemberServiceDTOs;
using SchoolApi.Infrastructure.Entities.UserGroups;

namespace SchoolApi.Infrastructure.Services.BusinessServices
{
    public interface IStudentService
    {
        public Task<Student> CreateSingleStudent(StudentCreateServiceRequest request);
        public Task<IEnumerable<Student>> CreateMultipleStudents(IEnumerable<StudentCreateServiceRequest> requests);
        public Task<Student> GetStudentDetail(string studentId);
        public Task<MultipleEntitiesResponse<Student>> GetMultipleStudents(int page);
        public Task<bool> DeleteSingleStudent(string studentId);
        public Task<bool> DeleteMultipleStudents(IEnumerable<string> studentIds);

        public Task<MultipleEntitiesResponse<Student>> SearchStudent(string searchTerm);
        public Task<bool> UpdateStudent(StudentUpdateServiceRequest request);

    }
    public class StudentService
    {
    }
}
