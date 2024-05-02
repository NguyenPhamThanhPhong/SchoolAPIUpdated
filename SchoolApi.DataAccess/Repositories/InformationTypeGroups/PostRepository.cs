using SchoolApi.Infrastructure.Configurations;
using SchoolApi.Infrastructure.Repositories.Base;
using SchoolApi.Infrastructure.Entities.InformationTypeGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchoolApi.Infrastructure.Repositories.InformationTypeGroups
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        public void RemoveRangeFromIds(IEnumerable<string> ids);
        public Post? GetDetailFromId(string id);
        public void RemoveSingleFromId(string postId);
    }
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(SchoolDbContext context) : base(context)
        {
        }

        public Post? GetDetailFromId(string id)
        {
            var post = _context.Set<Post>().Include(s => s.faculties).FirstOrDefault(x => x.id == id);
            return post;
        }

        public void RemoveRangeFromIds(IEnumerable<string> ids)
        {
            //var faculties = _context.Set<Post>()
            //.Where(x => ids.Contains(x.id))
            //.Select(x => new
            //{
            //    post = x,
            //    hasOwnerShip = false,
            //}).ToList();
            //foreach (var post in faculties)
            //{
            //    if (post.hasOwnerShip)
            //        post.post.isDeleted = true;
            //    else
            //        _context.Remove(post.post);
            //}
        }

        public void RemoveSingleFromId(string postId)
        {
        }
    }
}
