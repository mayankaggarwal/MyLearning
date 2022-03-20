using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.CM.Common.Caching
{
    public interface ICache
    {
        void Set<K, V>(K key, V value);
        Task<V> Get<K, V>(K key);
        Task<T> Invoke<T>(Expression<Func<T>> expression);
        Task<T> InvokeUpdate<T>(Expression<Func<T>> expression);
    }
}
