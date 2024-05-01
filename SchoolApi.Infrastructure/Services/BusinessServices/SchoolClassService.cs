using SchoolApi.Infrastructure.Entities.SchoolClassGroups;
using SchoolApi.Infrastructure.ServiceDTOS;
using SchoolApi.Infrastructure.ServiceDTOS.SchoolClassServiceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Services.BusinessServices
{
    public interface ISchoolClassService
    {
        public Task<SchoolClass> CreateSingleSchoolClass(SchoolClassCreateServiceRequest request);
        public Task<IEnumerable<SchoolClass>> CreateMultipleSchoolClasses(IEnumerable<SchoolClassCreateServiceRequest> requests);
        public Task<SchoolClass> GetSchoolClassDetail(string semesterId);
        public Task<MultipleEntitiesResponse<SchoolClass>> GetMultipleSchoolClasses(int page);
        public Task<bool> DeleteSchoolClass(string semesterId);
        public Task<MultipleEntitiesResponse<SchoolClass>> SearchSchoolClass(string searchTerm);
    }
    public class SchoolClassService : ISchoolClassService
    {
        public Task<IEnumerable<SchoolClass>> CreateMultipleSchoolClasses(IEnumerable<SchoolClassCreateServiceRequest> requests)
        {
            throw new NotImplementedException();
        }

        public Task<SchoolClass> CreateSingleSchoolClass(SchoolClassCreateServiceRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSchoolClass(string semesterId)
        {
            throw new NotImplementedException();
        }

        public Task<MultipleEntitiesResponse<SchoolClass>> GetMultipleSchoolClasses(int page)
        {
            throw new NotImplementedException();
        }

        public Task<SchoolClass> GetSchoolClassDetail(string semesterId)
        {
            throw new NotImplementedException();
        }

        public Task<MultipleEntitiesResponse<SchoolClass>> SearchSchoolClass(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
