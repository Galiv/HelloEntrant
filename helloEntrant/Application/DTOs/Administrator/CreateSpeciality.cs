using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTOs.Administrator
{
    public class CreateSpeciality
    {
        [Required]
        public string SpecialityName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int BudgetPlaceNumber { get; set; }
        [Required]
        public int PaidPlaceNumber { get; set; }
        [Required]        
        public string TestNeeded1 { get; set; }
        [Required]
        public string TestNeeded2 { get; set; }
        [Required]
        public string TestNeeded3 { get; set; }
        
        public string FucaltyName { get; set; }

    }
}
