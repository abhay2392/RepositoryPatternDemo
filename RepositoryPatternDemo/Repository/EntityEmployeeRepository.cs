using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepositoryPatternDemo.DAL;
using RepositoryPatternDemo.GenericRepository;

namespace RepositoryPatternDemo.Repository
{
    public class EntityEmployeeRepository : GenericRepository<Employee>, IEntityEmployeeRepository
    {
        private EmployeeDBContext _context;
        public EntityEmployeeRepository(EmployeeDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetEmployeesByDepartment(string Dept)
        {
            return _context.Employees.Where(e => e.Dept == Dept).ToList();

        }

        public IEnumerable<Employee> GetEmployeesByGender(string Gender)
        {
            return _context.Employees.Where(e => e.Gender == Gender).ToList();
        }

       
    }
}