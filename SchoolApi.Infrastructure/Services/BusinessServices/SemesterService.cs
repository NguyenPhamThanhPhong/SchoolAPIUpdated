using AutoMapper;
using SchoolApi.Infrastructure.Entities.InformationTypeGroups;
using SchoolApi.Infrastructure.Repositories.Base;
using SchoolApi.Infrastructure.ServiceDTOS.Semester;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Services.BusinessServices
{
    public interface ISemesterService
    {
        public Task<Semester> CreateSemester(SemesterCreateServiceRequest request);
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
        public Task<Semester> CreateSemester(SemesterCreateServiceRequest request)
        {
            var semester = _mapper.Map<SemesterCreateServiceRequest, Semester>(request);
            Console.WriteLine(semester.id??"id is null");
            _unitOfWork.semesterRepository.Add(semester);
            return Task.FromResult(new Semester());
        }

    }
}
