using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("Employee")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeController()
        {
            _employeeRepository = new EmployeeRepository();
        }

        [HttpGet, Route("Index")]
        public ViewResult Index()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        [HttpGet, Route("Datails/{id}")]
        public ViewResult Datails(int Id)
        {
            Employee model = _employeeRepository.GetEmployee(Id);

            return View(model);
        }
    }
}
