using AutoMapper;
using Microsoft.Data.SqlClient;
using SchoolApi.Infrastructure.Entities.InformationTypeGroups;
using SchoolApi.Infrastructure.Repositories.Base;
using SchoolApi.Infrastructure.ServiceDTOS;
using SchoolApi.Infrastructure.ServiceDTOS.FacultyServiceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Services.BusinessServices
{
    public interface IFacultyService
    {
        public Task<Faculty> CreateSingleFaculty(FacultyCreateServiceRequest request);
        public Task<MultipleEntitiesResponse<Faculty>> CreateMultipleFaculties(IEnumerable<FacultyCreateServiceRequest> requests);
        public Task<Faculty> GetFacultyDetail(string facultyId);
        public Task<MultipleEntitiesResponse<Faculty>> GetMultipleFaculties(int page);
        public Task<bool> DeleteSingleFaculty(string facultyId);
        public Task<bool> DeleteMultipleFaculties(IEnumerable<string> facultyIds);
        public Task<MultipleEntitiesResponse<Faculty>> SearchFaculty(string searchTerm);
        public Task<Faculty> UpdateFaculty(FacultyUpdateServiceRequest request);
    }
    public class FacultyService : IFacultyService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitofWork;

        public FacultyService(IMapper mapper, UnitOfWork unitofWork)
        {
            _mapper = mapper;
            _unitofWork = unitofWork;
        }

        public Task<MultipleEntitiesResponse<Faculty>> CreateMultipleFaculties(IEnumerable<FacultyCreateServiceRequest> requests)
        {
            var faculties = _mapper.Map<IEnumerable<Faculty>>(requests);
            _unitofWork.facultyRepository.AddRange(faculties);
            _unitofWork.Save();
            var result = new MultipleEntitiesResponse<Faculty>() { datas = faculties };
            return Task.FromResult(result);
        }

        public Task<Faculty> CreateSingleFaculty(FacultyCreateServiceRequest request)
        {
            var faculty = _mapper.Map<Faculty>(request);
            _unitofWork.facultyRepository.Add(faculty);
            _unitofWork.Save();
            return Task.FromResult(faculty);
        }

        public Task<bool> DeleteMultipleFaculties(IEnumerable<string> facultyIds)
        {
            var faculties = _unitofWork.facultyRepository.GetRange(
                    predicate: s => facultyIds.Contains(s.id),
                    page: -1, pageSize: -1);
            try
            {
                _unitofWork.facultyRepository.RemoveRange(faculties);
            }
            catch(SqlException ex)
            {
                //if exception is about remove entities with owner ship

            }

        }

        public Task<bool> DeleteSingleFaculty(string facultyId)
        {
            throw new NotImplementedException();
        }

        public Task<Faculty> GetFacultyDetail(string facultyId)
        {
            throw new NotImplementedException();
        }

        public Task<MultipleEntitiesResponse<Faculty>> GetMultipleFaculties(int page)
        {
            throw new NotImplementedException();
        }

        public Task<MultipleEntitiesResponse<Faculty>> SearchFaculty(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task<Faculty> UpdateFaculty(FacultyUpdateServiceRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
