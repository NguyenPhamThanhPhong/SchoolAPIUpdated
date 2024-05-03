using SchoolApi.Infrastructure.Entities.InformationTypeGroups;
using SchoolApi.Infrastructure.ServiceDTOS.SemesterServiceDTOs;
using SchoolApi.Infrastructure.ServiceDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolApi.Infrastructure.Entities.UserGroups;
using SchoolApi.Infrastructure.ServiceDTOS.SchoolMemberServiceDTOs;
using AutoMapper;
using SchoolApi.Infrastructure.Repositories.Base;
using SchoolApi.Infrastructure.Services.AzureBlobServices;
using SchoolApi.Infrastructure.ServiceDTOS.Base;
using SchoolApi.Infrastructure.Helper;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace SchoolApi.Infrastructure.Services.BusinessServices
{
    public interface ILecturerService
    {
        Task<Lecturer?> CreateSingleLecturer(LecturerCreateServiceRequest request);
        Task<Lecturer?> GetLecturerDetail(string lecturerId);
        Task<MultipleEntitiesResponse<Lecturer>> GetMultipleLecturers(BaseGetMultipleServiceRequest request);
        Task<bool> DeleteSingleLecturer(string lecturerId);
        Task<bool> DeleteMultipleLecturers(IEnumerable<string> lecturerIds);
        Task<MultipleEntitiesResponse<Lecturer>> SearchLecturer(BaseSearchServiceRequest request);
        Task<Lecturer?> UpdateLecturer(LecturerUpdateServiceRequest request);
    }
    public class LecturerService : ILecturerService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AzureBlobHandler _azureBlobHandler;

        public LecturerService(UnitOfWork unitOfWork, IMapper mapper, AzureBlobHandler azureBlobHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _azureBlobHandler = azureBlobHandler;
        }

        public virtual Task<Lecturer?> CreateSingleLecturer(LecturerCreateServiceRequest request)
        {
            try
            {
                var lecturer = _mapper.Map<Lecturer>(request);
                if(request.file != null)
                    lecturer.userProfile.avatarUrl = _azureBlobHandler.UploadSingleBlob(request.file).Result??"";
                _unitOfWork.lecturerRepository.Add(lecturer);
                _unitOfWork.Save();
                return Task.FromResult<Lecturer?>(lecturer);
            }
            catch { return Task.FromResult<Lecturer?>(null); }
        }

        public virtual Task<bool> DeleteMultipleLecturers(IEnumerable<string> lecturerIds)
        {
            try
            {
                IEnumerable<string?> avatarUrls = _unitOfWork.lecturerRepository.RemoveRangeFromIds(lecturerIds);
                IEnumerable<string> avatarUrlsNotNull = avatarUrls.Where(s => s != null).Select(s => s!);
                _azureBlobHandler.DeleteMultipleBlobs(avatarUrlsNotNull).Wait();
                _unitOfWork.Save();
                return Task.FromResult(true);
            }
            catch { return Task.FromResult(false); }
        }

        public virtual Task<bool> DeleteSingleLecturer(string lecturerId)
        {
            try
            {
                var deletedLecturer = _unitOfWork.lecturerRepository.RemoveSingleFromId(lecturerId);
                _unitOfWork.Save();
                if (deletedLecturer != null)
                    _azureBlobHandler.DeleteBlob(deletedLecturer.userProfile.avatarUrl).Wait();
                return Task.FromResult(true);
            }
            catch { return Task.FromResult(false);}
        }

        public virtual Task<Lecturer?> GetLecturerDetail(string lecturerId)
        {
            try
            {
                return Task.FromResult(_unitOfWork.lecturerRepository.GetLecturerDetail(lecturerId));
            }
            catch { return Task.FromResult<Lecturer?>(null);}
        }

        public virtual Task<MultipleEntitiesResponse<Lecturer>> GetMultipleLecturers(BaseGetMultipleServiceRequest request)
        {
            try
            {
                var lectuers = _unitOfWork.lecturerRepository.GetRange(s => true)
                    .Skip(request.page*request.pageSize).Take(request.pageSize);
                var count = _unitOfWork.lecturerRepository.GetCountDefault();
                return Task.FromResult(new MultipleEntitiesResponse<Lecturer>(true) { datas = lectuers, TotalCount = count });
            }catch { return Task.FromResult(new MultipleEntitiesResponse<Lecturer>(false)); }
        }

        public virtual Task<MultipleEntitiesResponse<Lecturer>> SearchLecturer(BaseSearchServiceRequest request)
        {
            try
            {
                string cleanSearchTerm = StringHelper.cleanSearchTerm(request.searchTerm);
                var lectuers = _unitOfWork.lecturerRepository.GetRange(s => 
                    EF.Functions.Like(s.userProfile.name.ToLower(),$"%{cleanSearchTerm}%"))
                    .Skip(request.page * request.pageSize).Take(request.pageSize);
                var count = _unitOfWork.lecturerRepository.GetCountDefault();
                return Task.FromResult(new MultipleEntitiesResponse<Lecturer>(true) { datas = lectuers, TotalCount = count });
            }
            catch { return Task.FromResult(new MultipleEntitiesResponse<Lecturer>(false)); }
        }

        public virtual Task<Lecturer?> UpdateLecturer(LecturerUpdateServiceRequest request)
        {
            try
            {
                var currentLecturer = _unitOfWork.context.Set<Lecturer>()
                    .Include(s => s.userProfile).FirstOrDefault();
                if (currentLecturer == null) 
                    return Task.FromResult<Lecturer?>(null);
                _mapper.Map(request, currentLecturer);
                if (request.file != null)
                    currentLecturer.userProfile.avatarUrl = _azureBlobHandler
                        .UploadSingleBlob(request.file).Result ?? "";
                Console.WriteLine(JsonSerializer.Serialize(currentLecturer));
                _unitOfWork.Save();
                return Task.FromResult<Lecturer?>(currentLecturer);
            }catch { return Task.FromResult<Lecturer?>(null);}
        }
    }
}
