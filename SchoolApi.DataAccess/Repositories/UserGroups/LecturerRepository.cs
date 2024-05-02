using SchoolApi.Infrastructure.Configurations;
using SchoolApi.Infrastructure.Repositories.Base;
using SchoolApi.Infrastructure.Entities.UserGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchoolApi.Infrastructure.Repositories.UserGroups
{
    public interface ILecturerRepository : IBaseRepository<Lecturer>
    {
        Lecturer? GetLecturerDetail(string lecturerId);
        public void RemoveRangeFromIds(IEnumerable<string> lecturerIds);
        public Lecturer? RemoveSingleFromId(string facultyId);
    }
    internal class LecturerRepository : BaseRepository<Lecturer>, ILecturerRepository
    {
        public LecturerRepository(SchoolDbContext context) : base(context)
        {
        }

        public Lecturer? GetLecturerDetail(string lecturerId)
        {
            return _context.Set<Lecturer>()
                    .Include(x => x.userProfile)
                    .Include(x => x.LecturerLogs).ThenInclude(x=>x.schoolClass)
                    .FirstOrDefault(x=>x.id == lecturerId);
        }

        public void RemoveRangeFromIds(IEnumerable<string> lecturerIds)
        {
            var lecturers = _context.Set<Lecturer>()
                .Where(x => lecturerIds.Contains(x.id))
                .Select(x => new
                {
                    lecturer = x,
                    hasOwnerShip = x.LecturerLogs.Any()
                }).ToList();
            foreach (var lecturer in lecturers)
            {
                if (lecturer.hasOwnerShip)
                    lecturer.lecturer.isDeleted = true;
                else
                    _context.Remove(lecturer.lecturer);
            }
        }

        public Lecturer? RemoveSingleFromId(string facultyId)
        {
            var lecturer = _context.Set<Lecturer>()
                .Where(x => x.id == facultyId)
                .Select(x => new
                {
                    lecturer = x,
                    hasOwnerShip = x.LecturerLogs.Any()
                }).FirstOrDefault();
            if (lecturer == null)
                return null;
            if (lecturer.hasOwnerShip)
                lecturer.lecturer.isDeleted = true;
            else
                _context.Remove(lecturer.lecturer);
            return lecturer.lecturer;
        }
    }
}
