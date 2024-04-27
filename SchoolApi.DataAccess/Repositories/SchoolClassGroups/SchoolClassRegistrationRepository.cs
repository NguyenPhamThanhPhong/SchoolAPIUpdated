using SchoolApi.Infrastructure.Configurations;
using SchoolApi.Infrastructure.Repositories.Base;
using SchoolApi.Infrastructure.Entities.SchoolClassGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Repositories.SchoolClassGroups
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
