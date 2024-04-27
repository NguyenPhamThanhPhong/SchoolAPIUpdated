using SchoolApi.DataAccess.DbContexts;
using SchoolApi.DataAccess.Repositories.Base;
using SchoolApi.Domain.Entities.UserGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.DataAccess.Repositories.UserGroups
{
    public interface ILecturerRepository : IBaseRepository<Lecturer>
    {
    }
    internal class LecturerRepository : BaseRepository<Lecturer>, ILecturerRepository
    {
        public LecturerRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
