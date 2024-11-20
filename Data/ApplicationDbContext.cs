using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentLoginReg.Models.StudentInfo;

namespace StudentLoginReg.Data
{
	public class ApplicationDbContext : IdentityDbContext<Student>
    {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Student> StudentsAccounts  { get; set; }
	}
}

