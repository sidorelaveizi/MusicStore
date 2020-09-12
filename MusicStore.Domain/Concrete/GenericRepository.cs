using MusicStore.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MusicStore.Domain.Abstract
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DbContext context;

        private readonly ApplicationDbContext _context = null;
        private readonly DbSet<T> table = null;

        public GenericRepository()
        {
            this._context = new ApplicationDbContext();
            table = _context.Set<T>();
        }
        public GenericRepository(ApplicationDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table;
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return table.Where(predicate);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().FirstOrDefault(predicate);
        }
        public void InsertCollection(IEnumerable<T> collection)
        {
            context.Set<T>().AddRange(collection);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().SingleOrDefault(predicate);
        }
        public void DeleteCollection(IEnumerable<T> collection)
        {
            context.Set<T>().RemoveRange(collection);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
