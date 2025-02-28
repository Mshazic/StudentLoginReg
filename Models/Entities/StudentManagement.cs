using System;
namespace StudentLoginReg.Models.Entities
{
	public class StudentManagement
    {
		public Guid Id { get; set; }

		public string? Name { get; set; }
		public string? Surname { get; set; }
		public string? Email { get; set; }
		public string? Phone { get; set; }
		public bool Subscribed { get; set; }

	}
}

