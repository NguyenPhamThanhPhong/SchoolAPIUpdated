using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Infrastructure.Entities.SchoolClassGroups;
using SchoolApi.Infrastructure.Helper;
using SchoolApi.Infrastructure.Repositories;
using SchoolApi.Infrastructure.Repositories.Base;
using SchoolApi.Infrastructure.ServiceDTOS;
using SchoolApi.Infrastructure.ServiceDTOS.Base;
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
        Task<SchoolClass?> CreateSingle(SchoolClassCreateServiceRequest request);
        Task<MultipleEntitiesResponse<SchoolClass>> CreateMultiple(IEnumerable<SchoolClassCreateServiceRequest> requests);
        Task<SchoolClass?> GetDetail(string schoolClassId);
        Task<MultipleEntitiesResponse<SchoolClass>> GetMultiple(BaseGetMultipleServiceRequest request);
        Task<bool> DeleteSingle(string schoolClassId);
        Task<bool> DeleteMany(IEnumerable<string> schoolClassIds);
        Task<MultipleEntitiesResponse<SchoolClass>> Search(string searchTerm);
        Task<SchoolClass?> Update(SchoolClassUpdateServiceRequest request);
    }
    public class SchoolClassService : ISchoolClassService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SchoolClassService(IMapper mapper, UnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task<MultipleEntitiesResponse<SchoolClass>> CreateMultiple(IEnumerable<SchoolClassCreateServiceRequest> requests)
        {
            try
            {
                var schoolClasses = _mapper.Map<IEnumerable<SchoolClass>>(requests);
                _unitOfWork.schoolClassRepository.AddRange(schoolClasses);
                return Task.FromResult(new MultipleEntitiesResponse<SchoolClass>(true) { datas=schoolClasses});
            }
            catch { return Task.FromResult(new MultipleEntitiesResponse<SchoolClass>(false)); }   
        }

        public Task<SchoolClass?> CreateSingle(SchoolClassCreateServiceRequest request)
        {
            try
            {
                var schoolClass = _mapper.Map<SchoolClass>(request);
                _unitOfWork.schoolClassRepository.Add(schoolClass);
                return Task.FromResult<SchoolClass?>(schoolClass);
            }
            catch { return Task.FromResult<SchoolClass?>(null);}
        }

        public Task<bool> DeleteSingle(string schoolClassId)
        {
            try
            {
                var schoolClass = _unitOfWork.schoolClassRepository.GetSingle(s => s.id == schoolClassId);
                if (schoolClass == null) return 
                        Task.FromResult(false);
                schoolClass.isDeleted = false;
                _unitOfWork.Save();
                return Task.FromResult(true);
            }
            catch { return Task.FromResult(false); }
        }

        public Task<MultipleEntitiesResponse<SchoolClass>> GetMultiple(BaseGetMultipleServiceRequest request)
        {
            try
            {
                var schoolClasses = _unitOfWork.schoolClassRepository.GetRange(s => true)
                    .Skip(request.page*request.pageSize).Take(request.pageSize);
                return Task.FromResult(new MultipleEntitiesResponse<SchoolClass>(true) { datas = schoolClasses });
            }
            catch { return Task.FromResult(new MultipleEntitiesResponse<SchoolClass>(false)); }
        }

        public Task<SchoolClass?> GetDetail(string schoolClassId)
        {
            try
            {
                var schoolClass = _unitOfWork.schoolClassRepository.GetDetail(schoolClassId);
                return Task.FromResult(schoolClass);
            }
            catch { return Task.FromResult<SchoolClass?>(null); }
        }

        public Task<MultipleEntitiesResponse<SchoolClass>> Search(string searchTerm)
        {
            try
            {
                string cleanSearchTerm = StringHelper.cleanSearchTerm(searchTerm);
                var schoolClasses = _unitOfWork.schoolClassRepository.GetRange(s => 
                    EF.Functions.Like(s.name.ToLower(), searchTerm));
                return Task.FromResult(new MultipleEntitiesResponse<SchoolClass>(true) { datas = schoolClasses });
            }
            catch { return Task.FromResult(new MultipleEntitiesResponse<SchoolClass>(false)); }
        }

        public Task<bool> DeleteMany(IEnumerable<string> schoolClassIds)
        {
            try
            {
                _unitOfWork.schoolClassRepository.GetRange(s => schoolClassIds.Contains(s.id))
                    .ToList().ForEach(s => s.isDeleted = false);
                return Task.FromResult(true);
            }
            catch { return Task.FromResult(false); }
        }

        public Task<SchoolClass?> Update(SchoolClassUpdateServiceRequest request)
        {
            try
            {
                var currentSchoolClass = _unitOfWork.schoolClassRepository.GetSingle(s => s.id==request.id);
                if (currentSchoolClass == null)
                    return Task.FromResult<SchoolClass?>(null);
                _mapper.Map(request, currentSchoolClass);
                _unitOfWork.Save();
                return Task.FromResult<SchoolClass?>(currentSchoolClass);
            }
            catch { return Task.FromResult<SchoolClass?>(null);}
        }
    }
}
