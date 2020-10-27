using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MusicStore.Domain.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Update(T obj);
        void Delete(object id);
        void Save();

    }
}
