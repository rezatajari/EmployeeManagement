using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly EmployeeRepository _employeeRepository;

        public HomeController()
        {
            _employeeRepository = new EmployeeRepository();
        }

        [HttpGet, Route("Index")]
        public ViewResult Index()
        {
            var employees = new List<Employee>
            {
                _employeeRepository.GetEmployee(1),
                _employeeRepository.GetEmployee(2),
                _employeeRepository.GetEmployee(3)
            };
            return View(employees);
        }

        [HttpGet, Route("Datails")]
        public ViewResult Datails(int Id)
        {
            Employee model = _employeeRepository.GetEmployee(Id);

            return View(model);
        }

        [HttpGet, Route("Create")]
        public ViewResult Create()
        {
            return View();
        }
    }
}
