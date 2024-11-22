using System;
using System.ComponentModel.DataAnnotations;

namespace StudentLoginReg.ViewModel
{
	public class RegisterViewModel
	{
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [EmailAddress]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be at and at max {1} charactes")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "Password does not match.")]
        public string? Password { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword { get; set; }

    }
}

