using SchoolApi.DataAccess.Repositories.Base;
using SchoolApi.Domain.Entities.SchoolClassGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.DataAccess.Repositories
{
    public interface ISchoolClassRepository: IBaseRepository<SchoolClass>
    {
    }
    public class SchoolClassRepository
    {
    }
}
