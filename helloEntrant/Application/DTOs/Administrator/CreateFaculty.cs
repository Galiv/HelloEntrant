using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTOs
{
    public class CreateFaculty
    {
        [Required]
        public string FacultyName { get; set; }
        [Required]
        public string Address { get; set; }       
        public string UserId { get; set; }
    }
}
