using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace dh.Media.CMP.Data.Repository
{
    public class RepositoryFactories
    {
        private IDictionary<Type, Func<DbContext, object>> GetCodeCamperFactories()
        {
            return new Dictionary<Type, Func<DbContext, object>> { };
        }

        public RepositoryFactories()
        {
            _repositoryFactories = GetCodeCamperFactories();
        }

        public RepositoryFactories(IDictionary<Type, Func<DbContext, object>> factories)
        {
            _repositoryFactories = factories;
        }

        public Func<DbContext, object> GetRepositoryFactory<T>()
        {

            Func<DbContext, object> factory;
            _repositoryFactories.TryGetValue(typeof(T), out factory);
            return factory;
        }

        public Func<DbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class
        {
            return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
        }

        protected virtual Func<DbContext, object> DefaultEntityRepositoryFactory<T>() where T : class
        {
            return dbContext => new Repository<T>(dbContext);
        }

        private readonly IDictionary<Type, Func<DbContext, object>> _repositoryFactories;
    }
}
