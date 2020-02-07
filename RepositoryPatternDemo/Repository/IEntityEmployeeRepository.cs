using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepositoryPatternDemo.DAL;
using RepositoryPatternDemo.GenericRepository;

namespace RepositoryPatternDemo.Repository
{
    public interface IEntityEmployeeRepository: IGenericRepository<Employee>
    {
        IEnumerable<Employee> GetEmployeesByGender(string Gender);
        IEnumerable<Employee> GetEmployeesByDepartment(string Dept);

    }
}