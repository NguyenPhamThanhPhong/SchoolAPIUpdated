using SchoolApi.Infrastructure.Configurations;
using SchoolApi.Infrastructure.Repositories.Base;
using SchoolApi.Infrastructure.Entities.InformationTypeGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Repositories.InformationTypeGroups
{
    public interface ISubjectRepository : IBaseRepository<Subject>
    {
        
    }
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(SchoolDbContext context) : base(context) { }

    }

}
