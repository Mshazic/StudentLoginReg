using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentLoginReg.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        public async Task<IActionResult> Login()
        {
            return View();
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        public async Task<IActionResult> ChangePassword()
        {
            return View();
        }

        public async Task<IActionResult> VerifyEmail()
        {
            return View();
        }
    }
}

