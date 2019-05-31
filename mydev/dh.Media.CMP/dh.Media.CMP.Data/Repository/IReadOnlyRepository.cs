﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace dh.Media.CMP.Data.Repository
{
    public interface IReadOnlyRepository<TEntity> where TEntity:class
    {
        IQueryable<TEntity> Get(bool asNoTracking = false,
            Expression<Func<TEntity,bool>> filter = null,
            Expression<Func<TEntity, object>>[] includeProperties = null,
            Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>> orderBy =null,
            int? skip=null, int? take = null);

        //IQueryable<TEntity> Get(bool asNoTracking = false,
        //    Expression<Func<TEntity, bool>> filter = null,
        //    Func<IQueryable<TEntity>, IIncludedQuerable<TEntity,object>> includeProperties = null,
        //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        //    int? skip = null, int? take = null);

        TEntity GetFirst(bool asNoTracking = false,
            Expression<Func<TEntity, bool>> filter = null,
            Expression<Func<TEntity, object>>[] includeProperties = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        TEntity GetById(int id);

        bool Exists(int id);
    }
}
