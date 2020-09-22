using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MusicStore.Domain.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        //T Add(T obj);

        void Insert(T obj);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Update(T obj);
        void Delete(object id);
        void DeleteCollection(IEnumerable<T> collection);

        T SingleOrDefault(Expression<Func<T, bool>> predicate);

        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        void InsertCollection(IEnumerable<T> collection);
        void Save();

    }
}
