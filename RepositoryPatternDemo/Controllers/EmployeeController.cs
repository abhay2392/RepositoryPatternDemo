using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepositoryPatternDemo.Repository;
using RepositoryPatternDemo.GenericRepository;
using RepositoryPatternDemo.DAL;

namespace RepositoryPatternDemo.Controllers
{
    public class EmployeeController : Controller
    {
        //private IEmployeeRepository _employeeRepository;
        private IGenericRepository<Employee> _employeeRepository;
        private EntityEmployeeRepository _entityRepository;

        public EmployeeController()
        {
            _employeeRepository = new GenericRepository<Employee>();
            _entityRepository = new EntityEmployeeRepository(new EmployeeDBContext());
        }

        public EmployeeController(IGenericRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        [HttpGet]
        public ActionResult Index()
        {
            // var model = _employeeRepository.GetAll();
            var model = _entityRepository.GetEmployeesByGender("Female");
            return View(model);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
           
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Insert(model);
                _employeeRepository.Save();
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditEmployee(int EmployeeId)
        {
            Employee employee=_employeeRepository.GetById(EmployeeId);
            return View(employee);

        }
        [HttpPost]
        public ActionResult EditEmployee(Employee model)
        {
            if(ModelState.IsValid)
            {
                _employeeRepository.Update(model);
                _employeeRepository.Save();
            }
            return View();
           
        }
        [HttpGet]
        public ActionResult DeleteEmployee(int EmployeeId)
        {
            Employee employee = _employeeRepository.GetById(EmployeeId);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(int EmployeeID)
        {
            if(ModelState.IsValid)
            {
                _employeeRepository.Delete(EmployeeID);
                _employeeRepository.Save();
                return RedirectToAction("Index");
            }
            return View();
           
        }

    }
}