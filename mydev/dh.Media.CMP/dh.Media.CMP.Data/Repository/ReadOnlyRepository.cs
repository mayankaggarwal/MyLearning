using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace dh.Media.CMP.Data.Repository
{
    public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        protected DbSet<TEntity> DbSet { get; }

        public ReadOnlyRepository(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        protected virtual IQueryable<TEntity> GetQuerable(bool asNoTracking = false, Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>>[] includeProperties = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? skip = null, int? take = null)
        {
            IQueryable<TEntity> query = DbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        public bool Exists(int id)
        {
            return GetById(id) != null;
        }

        public IQueryable<TEntity> Get(bool asNoTracking = false, Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>>[] includeProperties = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? skip = null, int? take = null)
        {
            return GetQuerable(asNoTracking, filter, includeProperties, orderBy, skip, take);            
        }

        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public TEntity GetFirst(bool asNoTracking = false, Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>>[] includeProperties = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return GetQuerable(asNoTracking, filter, includeProperties, orderBy).FirstOrDefault();
        }
    }
}
