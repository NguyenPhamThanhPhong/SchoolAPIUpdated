using SchoolApi.DataAccess.Configurations;
using SchoolApi.DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.DataAccess.Repositories.SchoolClassGroups
{
    public interface ISchoolClassRepository : IBaseRepository<SchoolClassRepository>
    {
    }
    public class SchoolClassRepository : BaseRepository<SchoolClassRepository>, ISchoolClassRepository
    {
        public SchoolClassRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
