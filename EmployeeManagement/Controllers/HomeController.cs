using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository,
                               IWebHostEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet, Route("Index")]
        public ViewResult Index()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return View(employees);
        }

        [HttpGet, Route("Datails/{id}")]
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

        [HttpPost, Route("Create")]
        public IActionResult Create(CreateEmployeeViewModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (employeeModel.Photo != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + employeeModel.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    employeeModel.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                var newEmploye = new Employee
                {
                    Name = employeeModel.Name,
                    Email = employeeModel.Email,
                    Department = employeeModel.Department,
                    PhotoPath = uniqueFileName
                };
                _employeeRepository.Add(newEmploye);

                return RedirectToAction("Datails", new { id = newEmploye.Id });
            };

            return View();
        }

    }
}
