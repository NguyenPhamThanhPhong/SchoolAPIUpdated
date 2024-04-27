using SchoolApi.DataAccess.DbContexts;
using SchoolApi.DataAccess.Repositories.Base;
using SchoolApi.Domain.Entities.InformationTypeGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.DataAccess.Repositories.InformationTypeGroups
{
    public interface ISemesterRepository : IBaseRepository<Semester>
    {
    }
    public class SemesterRepository : BaseRepository<Semester>, ISemesterRepository
    {
        public SemesterRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
