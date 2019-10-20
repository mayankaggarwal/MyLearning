using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.DataSource.Contracts
{
    public interface IDataSource
    {
        Task<DbResponse> Create<T>(string key, T value, TimeSpan? expiration = null) where T : class;
        T Get<T>(string documentId) where T : class;
        void Remove(string documentId);
        Task<DbResponse> Set<T>(string key, T value) where T : class;
    }
}
