using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepositoryPatternDemo.DAL;

namespace RepositoryPatternDemo.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly EmployeeDBContext _context;

        public EmployeeRepository()
        {
            _context = new EmployeeDBContext();
        }
        public EmployeeRepository(EmployeeDBContext context)
        {
            _context = context;
        }
        public void Delete(int EmployeeID)
        {
            Employee employee = _context.Employees.Find(EmployeeID);
            _context.Employees.Remove(employee);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee GetById(int EmployeeID)
        {
            return _context.Employees.Find(EmployeeID);
        }

        public void Insert(Employee employee)
        {
            _context.Employees.Add(employee);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Employee employee)
        {
            _context.Entry(employee).State = System.Data.Entity.EntityState.Modified;
        }
    }
}