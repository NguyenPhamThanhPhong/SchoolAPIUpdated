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
    public class StudentService : IStudentService
    {
        public Task<IEnumerable<Student>> CreateMultipleStudents(IEnumerable<StudentCreateServiceRequest> requests)
        {
            throw new NotImplementedException();
        }

        public Task<Student> CreateSingleStudent(StudentCreateServiceRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMultipleStudents(IEnumerable<string> studentIds)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSingleStudent(string studentId)
        {
            throw new NotImplementedException();
        }

        public Task<MultipleEntitiesResponse<Student>> GetMultipleStudents(int page)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetStudentDetail(string studentId)
        {
            throw new NotImplementedException();
        }

        public Task<MultipleEntitiesResponse<Student>> SearchStudent(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStudent(StudentUpdateServiceRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
