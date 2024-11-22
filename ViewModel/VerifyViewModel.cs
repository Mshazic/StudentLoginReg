using System;
using System.ComponentModel.DataAnnotations;

namespace StudentLoginReg.ViewModel
{
	public class VerifyViewModel
	{

        [Required(ErrorMessage = "Name is required")]
        [EmailAddress]
        public string? Email { get; set; }
    }
}

