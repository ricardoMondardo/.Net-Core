using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Web.Repository.Models;

namespace Web.Repository.Interfaces
{
    public interface IGerericRepository<TEntity> where TEntity : class, IEntityBase, new()
    {
        Task<TEntity> GetAsync(string id);
        Task<IEnumerable<TEntity>> GetAllAsync();

        int Count();
        TEntity Get(string id);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        List<TEntity> GetAll();
        IQueryable<TEntity> Find();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
