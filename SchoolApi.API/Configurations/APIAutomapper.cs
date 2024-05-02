using AutoMapper;
using SchoolApi.API.DTOS.Faculty;
using SchoolApi.API.DTOS.SchoolMember;
using SchoolApi.API.DTOS.Semester;
using SchoolApi.Infrastructure.Entities.InformationTypeGroups;
using SchoolApi.Infrastructure.Entities.UserGroups;
using SchoolApi.Infrastructure.ServiceDTOS.FacultyServiceDTOs;
using SchoolApi.Infrastructure.ServiceDTOS.SchoolMemberServiceDTOs;
using SchoolApi.Infrastructure.ServiceDTOS.SemesterServiceDTOs;

namespace SchoolApi.API.Configurations
{
    public class APIAutomapper : Profile
    {
        public APIAutomapper()
        {
            CreateMap<SemesterCreateRequest, SemesterCreateServiceRequest>();
            CreateMap<SemesterCreateServiceRequest, Semester>()
                .ForMember(dest => dest.id, opt => Guid.NewGuid().ToString());

            CreateMap<FacultyCreateRequest, FacultyCreateServiceRequest>();
            CreateMap<FacultyCreateServiceRequest, Faculty>();
            CreateMap<FacultyUpdateRequest, FacultyUpdateServiceRequest>();
            CreateMap<FacultyUpdateServiceRequest, Faculty>();
            _createSchoolMemberMaps();
        }
        private void _createSchoolMemberMaps()
        {
            CreateMap<UserProfileRequest, UserProfile>();
            CreateMap<LecturerCreateRequest, LecturerCreateServiceRequest>();
            CreateMap<LecturerCreateServiceRequest, Lecturer>();
            CreateMap<LecturerUpdateRequest, LecturerUpdateServiceRequest>();
            CreateMap<LecturerUpdateServiceRequest, Lecturer>();
        }

    }
}