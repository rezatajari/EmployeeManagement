using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeController()
        {
            _employeeRepository = new EmployeeRepository();
        }

        [HttpGet, Route("Employee/Index/{id}")]
        public string Index(int Id)
        {
            return _employeeRepository.GetEmployee(Id).Name;
        }

        [HttpGet, Route("Employee/Datails/{id}")]
        public JsonResult Datails(int Id)
        {
            Employee model = _employeeRepository.GetEmployee(Id);

            return Json(model);
        }
    }
}
