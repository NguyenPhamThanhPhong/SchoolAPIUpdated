using SchoolApi.Infrastructure.Repositories.Base;
using SchoolApi.Infrastructure.Entities.SchoolClassGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolApi.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace SchoolApi.Infrastructure.Repositories
{
    public interface ISchoolClassRepository: IBaseRepository<SchoolClass>
    {
        SchoolClass? GetDetail(string schoolClassId);
    }
    public class SchoolClassRepository: BaseRepository<SchoolClass>, ISchoolClassRepository
    {
        public SchoolClassRepository(SchoolDbContext context) : base(context)
        {
        }

        public SchoolClass? GetDetail(string schoolClassId)
        {
            var schoolClass = _context.Set<SchoolClass>()
                .Include(s => s.lecturerLog).ThenInclude(l => l.schoolMember)
                .Include(s => s.studentLogs).ThenInclude(s => s.schoolMember)
                .Include(s => s.subject)
                .Include(s => s.semester)
                .Include(s => s.schedule)
                .Include(s => s.sections)
                .Include(s => s.exams).FirstOrDefault();
            return schoolClass;
        }
    }

}
