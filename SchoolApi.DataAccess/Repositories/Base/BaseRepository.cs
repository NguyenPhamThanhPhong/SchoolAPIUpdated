using SchoolApi.DataAccess.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.DataAccess.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetRange(Expression<Func<TEntity,bool>> predicate,int page,int pageSize);
        TEntity? GetSingle(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
    public class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly SchoolDbContext _context;

        public BaseRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> GetRange(Expression<Func<TEntity, bool>> predicate, 
            int page=0, int pageSize = 10)
        {
            return _context.Set<TEntity>().Where(predicate)
                .Skip(page * pageSize)
                .Take(pageSize);
        }
        public TEntity? GetSingle(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
             _context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
             _context.Set<TEntity>().Update(entity);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _context.UpdateRange(entities);
        }
    }
}
