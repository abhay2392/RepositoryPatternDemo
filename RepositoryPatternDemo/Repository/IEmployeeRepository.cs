using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepositoryPatternDemo.DAL;

namespace RepositoryPatternDemo.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int EmployeeID);
        void Insert(Employee employee);
        void Update(Employee employee);
        void Delete(int EmployeeID);
        void Save();


    }
}