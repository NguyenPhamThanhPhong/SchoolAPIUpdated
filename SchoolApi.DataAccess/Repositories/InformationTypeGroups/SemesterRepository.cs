using SchoolApi.Infrastructure.Configurations;
using SchoolApi.Infrastructure.Repositories.Base;
using SchoolApi.Infrastructure.Entities.InformationTypeGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchoolApi.Infrastructure.Repositories.InformationTypeGroups
{
    public interface ISemesterRepository : IBaseRepository<Semester>
    {
        public void RemoveRangeFromIds(IEnumerable<string> ids);
        public Semester? GetDetailFromId(string id);
        public void RemoveSingleFromId(string facultyId);
    }
    public class SemesterRepository : BaseRepository<Semester>, ISemesterRepository
    {
        public SemesterRepository(SchoolDbContext context) : base(context)
        {
        }

        public Semester? GetDetailFromId(string id)
        {
            var semester = _context.Set<Semester>()
                .Include(x => x.schoolClasses)
                .Where(x => x.id == id).FirstOrDefault();
            return semester;
        }

        public void RemoveRangeFromIds(IEnumerable<string> ids)
        {
            var semesters = _context.Set<Semester>()
                .Where(x => ids.Contains(x.id))
                .Select(x => new
                {
                    semester = x,
                    hasOwnerShip = x.schoolClasses.Any() && x.scheduleTables.Any()
                }).ToList();
            foreach (var semester in semesters)
            {
                if (semester.hasOwnerShip)
                    semester.semester.isDeleted = true;
                else
                    _context.Remove(semester.semester);
            }
        }

        public void RemoveSingleFromId(string facultyId)
        {
            var semester = _context.Set<Semester>()
                .Where(x => x.id == facultyId)
                .Select(x => new
                {
                    semester = x,
                    hasOwnerShip = x.schoolClasses.Any() && x.scheduleTables.Any()
                }).FirstOrDefault();
            if (semester == null) 
                return;
            if (semester.hasOwnerShip)
                semester.semester.isDeleted = true;
            else
                _context.Remove(semester.semester);
        }
    }
}
