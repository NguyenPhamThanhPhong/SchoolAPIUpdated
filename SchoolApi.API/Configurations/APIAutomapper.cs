using AutoMapper;
using SchoolApi.API.DTOS.Semester;
using SchoolApi.Infrastructure.Entities.InformationTypeGroups;
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
        }
    }
}
