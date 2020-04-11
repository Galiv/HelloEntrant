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
        public int budgetPlace { get; set; }
        [Required]
        public int paidPlace { get; set; }
        [Required]
        public string testNeeded1 { get; set; }
        [Required]
        public string testNeeded2 { get; set; }
        [Required]
        public string testNeeded3 { get; set; }
        [Required]
        public string FucaltyName { get; set; }

    }
}
