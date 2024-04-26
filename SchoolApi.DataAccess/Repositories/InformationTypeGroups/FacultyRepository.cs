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
