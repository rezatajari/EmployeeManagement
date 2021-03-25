using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        [HttpGet, Route("Register")]
        public ViewResult Register()
        {
            return View();
        }
    }
}
