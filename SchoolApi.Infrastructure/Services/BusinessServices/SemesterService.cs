using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Infrastructure.Entities.InformationTypeGroups;
using SchoolApi.Infrastructure.Entities.UserGroups;
using SchoolApi.Infrastructure.Repositories.Base;
using SchoolApi.Infrastructure.ServiceDTOS;
using SchoolApi.Infrastructure.ServiceDTOS.Base;
using SchoolApi.Infrastructure.ServiceDTOS.SemesterServiceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Services.BusinessServices
{
    public interface ISemesterService
    {
        public Task<Semester> CreateSingleSemester(SemesterCreateServiceRequest request);
        public Task<IEnumerable<Semester>> CreateMultipleSemesters(IEnumerable<SemesterCreateServiceRequest> requests);
        public Task<Semester?> GetSemesterDetail(string semesterId);
        public Task<MultipleEntitiesResponse<Semester>> GetMultipleSemesters(BaseGetMultipleServiceRequest request);
        public Task<bool> DeleteSingleSemester(string semesterId);
        public Task<bool> DeleteMultipleSemesters(IEnumerable<string> semesterIds);
        public Task<MultipleEntitiesResponse<Semester>> SearchSemester(BaseSearchServiceRequest request);
        public Task<Semester?> UpdateSemester(SemesterUpdateServiceRequest request);
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

        public Task<MultipleEntitiesResponse<Semester>> GetMultipleSemesters(BaseGetMultipleServiceRequest request)
        {
            var semesters = _unitOfWork.semesterRepository.GetRange(s => true)
                .Skip(request.page * request.pageSize).Take(request.pageSize);
            var count = _unitOfWork.semesterRepository.GetCountDefault();
            return Task.FromResult(
                new MultipleEntitiesResponse<Semester>(true) { datas = semesters, TotalCount = count });
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

        public Task<MultipleEntitiesResponse<Semester>> SearchSemester(BaseSearchServiceRequest request)
        {
            int page = request.page;
            int pageSize = request.pageSize;
            var cleanSearchTerm = Regex.Replace(request.searchTerm, "[^a-zA-Z0-9]", "");
            var semesters = _unitOfWork.semesterRepository.GetRange(s => EF.Functions.Like(s.name.ToLower(), $"%{cleanSearchTerm}%"));
            var count = semesters.Count();
            semesters = semesters.Skip(page * pageSize).Take(pageSize);
            return Task.FromResult(
                new MultipleEntitiesResponse<Semester>(true) { datas = semesters, TotalCount = count });
        }

        public Task<bool> DeleteMultipleSemesters(IEnumerable<string> semesterIds)
        {
            try
            {
                _unitOfWork.semesterRepository.RemoveRangeFromIds(semesterIds);
                _unitOfWork.Save();
                return Task.FromResult(true);
            }
            catch { return Task.FromResult(false); }
        }

        public Task<Semester?> UpdateSemester(SemesterUpdateServiceRequest request)
        {
            try
            {
                var semester = _unitOfWork.semesterRepository.GetSingle(s=>s.id==request.id);
                _mapper.Map(request, semester);
                _unitOfWork.Save();
                return Task.FromResult(semester);
            }
            catch { return Task.FromResult<Semester?>(null); }
        }

    }
}
