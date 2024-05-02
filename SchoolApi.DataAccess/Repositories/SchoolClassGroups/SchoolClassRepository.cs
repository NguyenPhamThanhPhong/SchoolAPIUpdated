using SchoolApi.Infrastructure.Configurations;
using SchoolApi.Infrastructure.Entities.SchoolClassGroups;
using SchoolApi.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Repositories.SchoolClassGroups
{
    public interface ISchoolClassRepository : IBaseRepository<SchoolClass>
    {
    }
    public class SchoolClassRepository : BaseRepository<SchoolClass>, ISchoolClassRepository
    {
        public SchoolClassRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
