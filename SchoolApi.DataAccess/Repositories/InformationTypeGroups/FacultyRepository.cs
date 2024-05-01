using SchoolApi.Infrastructure.Configurations;
using SchoolApi.Infrastructure.Repositories.Base;
using SchoolApi.Infrastructure.Entities.InformationTypeGroups;
using Microsoft.EntityFrameworkCore;

namespace SchoolApi.Infrastructure.Repositories.InformationTypeGroups
{
    public interface IFacultyRepository : IBaseRepository<Faculty>
    {
        public void RemoveRangeFromIds(IEnumerable<string> ids);
        public Faculty? GetDetailFromId(string id);
        public void RemoveSingleFromId(string facultyId);
    }
    public class FacultyRepository : BaseRepository<Faculty>,IFacultyRepository
    {
        public FacultyRepository(SchoolDbContext context) : base(context)
        {

        }
        public void RemoveRangeFromIds(IEnumerable<string> ids)
        {
            var faculties = _context.Set<Faculty>()
                .Where(x => ids.Contains(x.id))
                .Select(x => new
                {
                    faculty = x,
                    hasOwnerShip= x.posts.Any() && x.subjects.Any()
                }).ToList();
            foreach (var faculty in faculties)
            {
                if (faculty.hasOwnerShip)
                    faculty.faculty.isDeleted = true;
                else
                    _context.Remove(faculty.faculty);
            }
        }
        public void RemoveSingleFromId(string id)
        {
            var faculty = _context.Set<Faculty>()
                .Where(x => x.id == id)
                .Select(x => new
                {
                    faculty = x,
                    hasOwnerShip = x.posts.Any() && x.subjects.Any()
                }).FirstOrDefault();
            if (faculty == null)
                return ;
            if(faculty.hasOwnerShip)
                faculty.faculty.isDeleted = true;
            else
                _context.Remove(faculty.faculty);
        }
        public Faculty? GetDetailFromId(string id)
        {
            var faculty = _context.Set<Faculty>()
                .Include(x => x.subjects)
                .Where(x => x.id == id).FirstOrDefault();
            return faculty;
        }

    }
}
