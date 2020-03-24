using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.SuperAdmin
{
    public class AddUniRequest
    {
        public string UniversityName { get; set; }
        
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
       
        [Required, Compare(nameof(Password), ErrorMessage = "There is a difference in your passwords. Please try again")]

        public string ConfirmPassword { get; set; }
    }
}
