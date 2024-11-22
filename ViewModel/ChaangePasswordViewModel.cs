using System;
using System.ComponentModel.DataAnnotations;

namespace StudentLoginReg.ViewModel
{
	public class ChaangePasswordViewModel
	{

        [Required(ErrorMessage = "Name is required")]
        [EmailAddress]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be at and at max {1} charactes")]
        [DataType(DataType.Password)]
        [Display(Name = "NewPassword")]
        [Compare("ConfirmNewPassword", ErrorMessage = "Password does not match.")]
        public string? NewPassword { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        public string? ConfirmNewPassword { get; set; }

    }
}

