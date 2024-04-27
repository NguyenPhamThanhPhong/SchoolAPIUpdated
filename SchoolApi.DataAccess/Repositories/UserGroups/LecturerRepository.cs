using SchoolApi.Infrastructure.Configurations;
using SchoolApi.Infrastructure.Repositories.Base;
using SchoolApi.Infrastructure.Entities.UserGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Repositories.UserGroups
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
