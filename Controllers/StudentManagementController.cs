using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentLoginReg.Data;
using StudentLoginReg.Models.Entities;
using StudentLoginReg.ViewModel.StudentManagement;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentLoginReg.Controllers
{
    public class StudentManagementController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public StudentManagementController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStdManagementViewModel viewModel)
        {
            var studentManagement = new StudentManagement
            {
                Name= viewModel.Name,
                Surname= viewModel.Surname,
                Email= viewModel.Email,
                Phone= viewModel.Phone,
                Subscribed= viewModel.Subscribed
            };

            await dbContext.StudentsManagement.AddAsync(studentManagement);
            await dbContext.SaveChangesAsync();

            return View();
        }
    }
}

