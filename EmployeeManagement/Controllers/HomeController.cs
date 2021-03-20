﻿using EmployeeManagement.Models;
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
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
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
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmploye = _employeeRepository.Add(employee);
                return RedirectToAction("Datails", new { id = newEmploye.Id });
            };

            return View();
        }
    }
}
