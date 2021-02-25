using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeController()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public string Index(int Id)
        {
            return _employeeRepository.GetEmployee(Id).Name;
        }


        public JsonResult Datails(int Id)
        {
            Employee model = _employeeRepository.GetEmployee(1);

            return Json(model);
        }
    }
}
