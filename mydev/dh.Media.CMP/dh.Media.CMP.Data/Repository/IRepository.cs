using System;
using System.Collections.Generic;
using System.Text;

namespace dh.Media.CMP.Data.Repository
{
    public interface IRepository<T>:IReadOnlyRepository<T> where T:class
    {
        void Add(T entity);
        void Delete(T entity);
        void Delete(int id);

        void Update(T entity);
        void Update(T entity, string[] properties);

    }
}
