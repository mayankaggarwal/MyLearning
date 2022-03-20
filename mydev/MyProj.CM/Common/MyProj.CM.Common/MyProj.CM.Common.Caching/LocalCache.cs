using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.CM.Common.Caching
{
    public class LocalCache : ICache
    {
        public Task<V> Get<K, V>(K key)
        {
            throw new NotImplementedException();
        }

        public Task<T> Invoke<T>(Expression<Func<T>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<T> InvokeUpdate<T>(Expression<Func<T>> expression)
        {
            throw new NotImplementedException();
        }

        public void Set<K, V>(K key, V value)
        {
            throw new NotImplementedException();
        }
    }
}
