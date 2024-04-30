using AutoMapper;
using SchoolApi.Infrastructure.Entities.InformationTypeGroups;
using SchoolApi.Infrastructure.Entities.UserGroups;
using SchoolApi.Infrastructure.Repositories.Base;
using SchoolApi.Infrastructure.ServiceDTOS;
using SchoolApi.Infrastructure.ServiceDTOS.SemesterServiceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Services.BusinessServices
{
    public interface ISemesterService
    {
        public Task<Semester> CreateSingleSemester(SemesterCreateServiceRequest request);
        public Task<IEnumerable<Semester>> CreateMultipleSemesters(IEnumerable<SemesterCreateServiceRequest> requests);
        public Task<Semester> GetSemesterDetail(string semesterId);
        public Task<MultipleEntitiesResponse<Semester>> GetMultipleSemesters(int page);
        public Task<bool> DeleteSemester(string semesterId);
        public Task<MultipleEntitiesResponse<Semester>> SearchSemester(string searchTerm);
    }
    public class SemesterService : ISemesterService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        public SemesterService(IMapper mapper,UnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public Task<Semester> CreateSingleSemester(SemesterCreateServiceRequest request)
        {
            var semester = _mapper.Map<SemesterCreateServiceRequest, Semester>(request);
            Console.WriteLine(semester.id??"id is null");
            _unitOfWork.semesterRepository.Add(semester);
            return Task.FromResult(new Semester());
        }
        public Task<IEnumerable<Semester>> CreateMultipleSemesters(IEnumerable<SemesterCreateServiceRequest> request)
        {
            var semesters = _mapper.Map<IEnumerable<SemesterCreateServiceRequest>, IEnumerable<Semester>>(request);
            _unitOfWork.semesterRepository.AddRange(semesters);
            return Task.FromResult(semesters);
        }

        public Task<Semester> GetSemesterDetail(string semesterId)
        {
            throw new NotImplementedException();
        }

        public Task<MultipleEntitiesResponse<Semester>> GetMultipleSemesters(int page)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSemester(string semesterId)
        {
            throw new NotImplementedException();
        }

        public Task<MultipleEntitiesResponse<Semester>> SearchSemester(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
