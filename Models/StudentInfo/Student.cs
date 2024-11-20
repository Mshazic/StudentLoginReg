using System;
using Microsoft.AspNetCore.Identity;

namespace StudentLoginReg.Models.StudentInfo
{
	public class Student : IdentityUser
	{
		public string? Fullname { get; set; }
	}
}

