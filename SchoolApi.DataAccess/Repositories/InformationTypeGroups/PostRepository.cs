using SchoolApi.Infrastructure.Configurations;
using SchoolApi.Infrastructure.Repositories.Base;
using SchoolApi.Infrastructure.Entities.InformationTypeGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Repositories.InformationTypeGroups
{
    public interface IPostRepository : IBaseRepository<Post>
    {
    }
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
