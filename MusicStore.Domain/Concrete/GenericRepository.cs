using MusicStore.Domain.Concrete;
using System.Collections.Generic;
using System.Data.Entity;

namespace MusicStore.Domain.Abstract
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
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
        public void Save()
        {
            _context.SaveChanges();
        }

        
    }
}
