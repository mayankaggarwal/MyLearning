using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace dh.Media.CMP.Data.Repository
{
    public class Repository<TEntity> : ReadOnlyRepository<TEntity>, IRepository<TEntity> where TEntity : class
    {
        public Repository(DbContext context):base(context)
        {

        }

        public virtual void Add(TEntity entity)
        {
            var dbEntityEntry = Context.Entry(entity);
            if(dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public virtual void Delete(TEntity entity)
        {
            var dbEntityEntry = Context.Entry(entity);
            if(dbEntityEntry.State != EntityState.Deleted)
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            Delete(entity);
        }

        public virtual void Update(TEntity entity)
        {
            var dbEntityEntry = Context.Entry(entity);
            if(dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public void Update(TEntity entity, string[] properties)
        {
            throw new NotImplementedException();
        }
    }
}
