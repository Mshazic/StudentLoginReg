using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

            return RedirectToAction("List", "StudentManagement");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var studentManagemet = await dbContext.StudentsManagement.ToListAsync();

            return View(studentManagemet);
        }

        //this is not done
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
           var studentManagement = await dbContext.StudentsManagement.FindAsync(id);

            return View(studentManagement);

        }

        [HttpPost]
        public  async Task<IActionResult> Edit(StudentManagement viewModel)
        {
            var studentManagement = await dbContext.StudentsManagement.FindAsync(viewModel.Id);
            if (studentManagement is not null)
            {
                studentManagement.Name = viewModel.Name;
                studentManagement.Surname = viewModel.Surname;
                studentManagement.Email = viewModel.Email;
                studentManagement.Phone = viewModel.Phone;
                studentManagement.Subscribed = viewModel.Subscribed;

                await dbContext.SaveChangesAsync();

            }

            return RedirectToAction("List","StudentManagement");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(StudentManagement viewModel)
        {
            var studentManagement = await dbContext.StudentsManagement
                .AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);


            if (studentManagement is not null)
            {
                dbContext.StudentsManagement.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
                        return RedirectToAction("List","StudentManagement");
        }
    }
}

