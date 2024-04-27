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
    public interface IStudentRepository : IBaseRepository<Student>
    {
    }
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
