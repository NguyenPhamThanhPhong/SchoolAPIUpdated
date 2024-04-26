using SchoolApi.DataAccess.Configurations;
using SchoolApi.DataAccess.Repositories.Base;
using SchoolApi.Domain.Entities.InformationTypeGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.DataAccess.Repositories.InformationTypeGroups
{
    public interface ISubjectRepository : IBaseRepository<Subject>
    {
        
    }
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(SchoolDbContext context) : base(context) { }

    }

}
