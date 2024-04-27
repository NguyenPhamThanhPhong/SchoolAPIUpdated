using SchoolApi.DataAccess.DbContexts;
using SchoolApi.DataAccess.Repositories.Base;
using SchoolApi.Domain.Entities;
using SchoolApi.Domain.Entities.UserGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.DataAccess.Repositories.UserGroups
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task<IEnumerable<User>> GetRangeByIds(IEnumerable<string> ids);
        public Task<User> GetSingleById(string id);
        public Task<User> GetByUserName(string userName);
        public Task<User> GetByEmail(string email);
        public Task<bool> UpdatePassword(User user, string password);

    }
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SchoolDbContext context) : base(context)
        {
            List<User> tests = new List<User>();
            tests.Add(new Student());
        }

        public Task<User> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetRangeByIds(IEnumerable<string> ids)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetSingleById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePassword(User user, string password)
        {
            throw new NotImplementedException();
        }
    }
}
