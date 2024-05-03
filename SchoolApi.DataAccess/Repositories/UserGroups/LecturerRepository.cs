using SchoolApi.Infrastructure.Configurations;
using SchoolApi.Infrastructure.Repositories.Base;
using SchoolApi.Infrastructure.Entities.UserGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Infrastructure.Entities.StudentSchoolClass;

namespace SchoolApi.Infrastructure.Repositories.UserGroups
{
    public interface ILecturerRepository : IBaseRepository<Lecturer>
    {
        Lecturer? GetLecturerDetail(string lecturerId);
        public IEnumerable<string?> RemoveRangeFromIds(IEnumerable<string> lecturerIds);
        public Lecturer? RemoveSingleFromId(string facultyId);
        public IEnumerable<LecturerLog> GetLecturerLogs(string lecturerId);
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

        public IEnumerable<LecturerLog> GetLecturerLogs(string id)
        {
            return _context.Set<LecturerLog>()
                .Include(x => x.schoolClass)
                .Where(x => x.schoolMemberId == id).ToList();
        }

        public IEnumerable<string?> RemoveRangeFromIds(IEnumerable<string> lecturerIds)
        {
            var lecturers = _context.Set<Lecturer>()
                .Where(x => lecturerIds.Contains(x.id))
                .Select(x => new
                {
                    lecturer = x,
                    avatarUrl = x.userProfile.avatarUrl,
                    hasOwnerShip = x.LecturerLogs.Any()
                }).ToList();
            foreach (var lecturer in lecturers)
            {
                if (lecturer.hasOwnerShip)
                    lecturer.lecturer.isDeleted = true;
                else
                    _context.Remove(lecturer.lecturer);
            }
            return lecturers.Select(x => x.avatarUrl);
        }

        public Lecturer? RemoveSingleFromId(string lecturerId)
        {
            var lecturer = _context.Set<Lecturer>()
                .Where(x => x.id == lecturerId)
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
