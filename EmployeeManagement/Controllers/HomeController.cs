using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

        [HttpGet, Route("Edit/{id}")]
        public ViewResult Edit(int Id)
        {
            Employee employee = _employeeRepository.GetEmployee(Id);

            EditEmployeeViewModel editEmployeeViewModel = new()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                PathPhoto = employee.PhotoPath
            };

            return View(editEmployeeViewModel);
        }

        [HttpPost, Route("Edit/{id}")]
        public IActionResult Edit(EditEmployeeViewModel updateModel)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployee(updateModel.Id);
                employee.Name = updateModel.Name;
                employee.Email = updateModel.Email;
                employee.Department = updateModel.Department;
                if (updateModel.Photo != null)
                {
                    if (updateModel.PathPhoto != null)
                    {
                        string pathFile = Path.Combine(_hostingEnvironment.WebRootPath,
                            "Images", updateModel.PathPhoto);
                        System.IO.File.Delete(pathFile);
                    }
                    employee.PhotoPath = ProcessFileUpload(updateModel.Photo);
                };

                _employeeRepository.Update(employee);

                return RedirectToAction("Index");
            }
            else
                throw new Exception("Your Employee is not exist");
        }

        [HttpGet, Route("Datails/{id}")]
        public ViewResult Datails(int Id)
        {
            Employee model = _employeeRepository.GetEmployee(Id);

            if (model == null) {

                Response.StatusCode = 404;
                return View("EmployeeIsNotExist", Id);
            }

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
                string uniqueFileName = ProcessFileUpload(employeeModel.Photo);

                var newEmploye = new Employee
                {
                    Name = employeeModel.Name,
                    Email = employeeModel.Email,
                    Department = employeeModel.Department,
                    PhotoPath = uniqueFileName
                };

                _employeeRepository.Add(newEmploye);
                return RedirectToAction("Datails", new { id = newEmploye.Id });
            }

            return View();

        }

        private string ProcessFileUpload(IFormFile photoFile)
        {
            string uniqueFileName = null;
            if (photoFile != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + photoFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                photoFile.CopyTo(fileStream);
            }

            return uniqueFileName;
        }
    }

}
