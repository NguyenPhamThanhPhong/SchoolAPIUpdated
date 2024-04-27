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
    public interface IFacultyRepository : IBaseRepository<Faculty>
    {
        public Task<IEnumerable<Faculty>> GetRangeRelatedSubject(string facultyId);

    }
    public class FacultyRepository : BaseRepository<Faculty>,IFacultyRepository
    {
        public FacultyRepository(SchoolDbContext context) : base(context)
        {

        }

        public Task<IEnumerable<Faculty>> GetRangeRelatedSubject(string facultyId)
        {
            throw new NotImplementedException();
        }
    }
}
