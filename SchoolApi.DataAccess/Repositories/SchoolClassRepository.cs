using SchoolApi.Infrastructure.Repositories.Base;
using SchoolApi.Infrastructure.Entities.SchoolClassGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Repositories
{
    public interface ISchoolClassRepository: IBaseRepository<SchoolClass>
    {
    }
    public class SchoolClassRepository
    {
    }
}
