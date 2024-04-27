using AutoMapper;
using SchoolApi.API.DTOS;
using SchoolApi.Infrastructure.Entities.InformationTypeGroups;
using SchoolApi.Infrastructure.ServiceDTOS.Semester;

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
