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
        public Task<Semester?> GetSemesterDetail(string semesterId);
        public Task<MultipleEntitiesResponse<Semester>> GetMultipleSemesters(int page);
        public Task<bool> DeleteSingleSemester(string semesterId);
        public Task<bool> DeleteMultipleSemesters(IEnumerable<string> semesterIds);
        public Task<MultipleEntitiesResponse<Semester>> SearchSemester(string searchTerm);
        public Task<Semester> UpdateSemester(SemesterUpdateServiceRequest request);
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
            Semester? semester = _mapper.Map<SemesterCreateServiceRequest, Semester>(request);
            _unitOfWork.semesterRepository.Add(semester);
            _unitOfWork.Save();
            return Task.FromResult(semester);
        }
        public Task<IEnumerable<Semester>> CreateMultipleSemesters(IEnumerable<SemesterCreateServiceRequest> request)
        {
            var semesters = _mapper.Map<IEnumerable<SemesterCreateServiceRequest>, IEnumerable<Semester>>(request);
            _unitOfWork.semesterRepository.AddRange(semesters);
            _unitOfWork.Save(); 
            return Task.FromResult(semesters);
        }

        public Task<Semester?> GetSemesterDetail(string semesterId)
        {
            var semester = _unitOfWork.semesterRepository.GetDetailFromId(semesterId);
            return Task.FromResult(semester);
        }

        public Task<MultipleEntitiesResponse<Semester>> GetMultipleSemesters(int page)
        {
            int pageSize = 10;
            var semesters= _unitOfWork.semesterRepository.GetRange(s=>s.schoolClasses.Any(),page,pageSize);
            var count = _unitOfWork.semesterRepository.GetCountDefault();
            return Task.FromResult(
                new MultipleEntitiesResponse<Semester> { datas = semesters, TotalCount = count });
        }

        public Task<bool> DeleteSingleSemester(string semesterId)
        {
            try
            {
                _unitOfWork.semesterRepository.RemoveSingleFromId(semesterId);
                _unitOfWork.Save();
                return Task.FromResult(true);
            }
            catch{return Task.FromResult(false);}
        }

        public Task<MultipleEntitiesResponse<Semester>> SearchSemester(string searchTerm)
        {
            try
            {
                _unitOfWork.semesterRepository.GetRange(s => s.name.Contains(searchTerm), 1, 10)
            }
        }

        public Task<bool> DeleteMultipleSemesters(IEnumerable<string> semesterIds)
        {
            throw new NotImplementedException();
        }

        public Task<Semester> UpdateSemester(SemesterUpdateServiceRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
