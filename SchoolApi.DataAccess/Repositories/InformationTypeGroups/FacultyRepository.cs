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
        public Task RemoveRangeFromIds(IEnumerable<string> ids)
        {
            // use sql CASE to check if is Ownership of something
            // if yes, set isDeleted to true
            //else remove
            // help me code here copilot
            var faculties = _context.Set<Faculty>()
                .Where(x => ids.Contains(x.id))
                .Select(x => new
                {
                    faculty = x,
                    hasOwnerShip= x.hasOwnerShip()
                }).ToList();
            foreach (var faculty in faculties)
            {
                if (faculty.hasOwnerShip)
                    faculty.faculty.isDeleted = true;
                else
                    _context.Set<Faculty>().Remove(faculty.faculty);

            }
        }

        public Task<IEnumerable<Faculty>> GetRangeRelatedSubject(string facultyId)
        {
            throw new NotImplementedException();
        }
    }
}
