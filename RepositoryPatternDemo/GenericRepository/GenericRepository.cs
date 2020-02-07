using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RepositoryPatternDemo.DAL;

namespace RepositoryPatternDemo.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private EmployeeDBContext _context = null;
        private DbSet<T> table = null;

        public GenericRepository()
        {
            _context = new EmployeeDBContext();
            table = _context.Set<T>();

        }

        public GenericRepository(EmployeeDBContext context)
        {
            _context = context;
            table = _context.Set<T>();

        }
        public void Delete(object id)
        {
            T obj = table.Find(id);
            table.Remove(obj);
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
           return table.Find(id);

        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Save()
        {

            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;

        }
    }
}