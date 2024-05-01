using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolApi.Infrastructure.Entities.InformationTypeGroups;
using SchoolApi.Infrastructure.Repositories.Base;
using SchoolApi.Infrastructure.ServiceDTOS;
using SchoolApi.Infrastructure.ServiceDTOS.FacultyServiceDTOs;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace SchoolApi.Infrastructure.Services.BusinessServices
{
    public interface IFacultyService
    {
        public Task<Faculty> CreateSingleFaculty(FacultyCreateServiceRequest request);
        public Task<MultipleEntitiesResponse<Faculty>> CreateMultipleFaculties(IEnumerable<FacultyCreateServiceRequest> requests);
        public Task<Faculty?> GetFacultyDetail(string facultyId);
        public Task<MultipleEntitiesResponse<Faculty>> GetMultipleFaculties(int page);
        public Task<bool> DeleteSingleFaculty(string facultyId);
        public Task<bool> DeleteMultipleFaculties(IEnumerable<string> facultyIds);
        public Task<MultipleEntitiesResponse<Faculty>> SearchFaculty(string searchTerm);
        public Task<Faculty?> UpdateFaculty(FacultyUpdateServiceRequest request);
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
            try
            {
                _unitofWork.facultyRepository.RemoveRangeFromIds(facultyIds);
                _unitofWork.Save();
                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> DeleteSingleFaculty(string facultyId)
        {
            try
            {
                _unitofWork.facultyRepository.RemoveSingleFromId(facultyId);
                _unitofWork.Save();
                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }

        public Task<Faculty?> GetFacultyDetail(string facultyId)
        {
            var faculty =  _unitofWork.facultyRepository.GetDetailFromId(facultyId);
            _unitofWork.Save();
            return Task.FromResult(faculty);
        }

        public  Task<MultipleEntitiesResponse<Faculty>> GetMultipleFaculties(int page)
        {
            var faculties =  _unitofWork.facultyRepository.GetRange(s=>true).Skip(page * 10).Take(10);
            var count = _unitofWork.facultyRepository.GetCountDefault();
            return Task.FromResult(new MultipleEntitiesResponse<Faculty>() { datas = faculties, TotalCount = count });
        }

        public Task<MultipleEntitiesResponse<Faculty>> SearchFaculty(string searchTerm)
        {
            var cleanSearchTerm = Regex.Replace(searchTerm, "[^a-zA-Z0-9]", "");
            var faculties = _unitofWork.facultyRepository.GetRange(s => EF.Functions.Like(s.name.ToLower(), $"%{cleanSearchTerm}%"));
            var count = faculties.Count();
            faculties = faculties.Skip(0).Take(10);
            return Task.FromResult(new MultipleEntitiesResponse<Faculty>() 
                    { datas = faculties, TotalCount = count });
        }
        public Task<Faculty?> UpdateFaculty(FacultyUpdateServiceRequest request)
        {
            var faculty = _unitofWork.facultyRepository.GetSingle(s => s.id == request.id);
            if(faculty!=null)
            {
                _mapper.Map(request, faculty);
                Console.WriteLine(JsonSerializer.Serialize(faculty));
                _unitofWork.facultyRepository.Update(faculty);
                _unitofWork.Save();
            }
            return Task.FromResult(faculty);
        }
    }
}
