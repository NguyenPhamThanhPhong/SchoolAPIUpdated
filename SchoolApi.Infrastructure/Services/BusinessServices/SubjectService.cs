using SchoolApi.Infrastructure.Entities.InformationTypeGroups;
using SchoolApi.Infrastructure.ServiceDTOS.SemesterServiceDTOs;
using SchoolApi.Infrastructure.ServiceDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolApi.Infrastructure.ServiceDTOS.SubjectServiceDTOs;

namespace SchoolApi.Infrastructure.Services.BusinessServices
{
    public interface ISubjectService
    {
        public Task<Subject> CreateSingleSubject(SubjectCreateServiceRequest request);
        public Task<IEnumerable<Subject>> CreateMultipleSubjects(IEnumerable<SubjectCreateServiceRequest> requests);
        public Task<Subject> GetSubjectDetail(string subjectId);
        public Task<MultipleEntitiesResponse<Subject>> GetMultipleSubjects(int page);
        public Task<bool> DeleteSubject(string subjectId);
        public Task<MultipleEntitiesResponse<Subject>> SearchSubject(string searchTerm);
    }
    public class SubjectService : ISubjectService
    {
        public Task<IEnumerable<Subject>> CreateMultipleSubjects(IEnumerable<SubjectCreateServiceRequest> requests)
        {
            throw new NotImplementedException();
        }

        public Task<Subject> CreateSingleSubject(SubjectCreateServiceRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSubject(string subjectId)
        {
            throw new NotImplementedException();
        }

        public Task<MultipleEntitiesResponse<Subject>> GetMultipleSubjects(int page)
        {
            throw new NotImplementedException();
        }

        public Task<Subject> GetSubjectDetail(string subjectId)
        {
            throw new NotImplementedException();
        }

        public Task<MultipleEntitiesResponse<Subject>> SearchSubject(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
