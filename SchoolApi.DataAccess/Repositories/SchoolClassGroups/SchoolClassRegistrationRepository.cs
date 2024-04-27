using SchoolApi.DataAccess.DbContexts;
using SchoolApi.DataAccess.Repositories.Base;
using SchoolApi.Domain.Entities.SchoolClassGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.DataAccess.Repositories.SchoolClassGroups
{
    public interface ISchoolClassRegistrationRepository : IBaseRepository<SchoolClassRegistration>
    {
    }
    public class SchoolClassRegistrationRepository : BaseRepository<SchoolClassRegistration>, ISchoolClassRegistrationRepository
    {
        public SchoolClassRegistrationRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
