using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Entities
{
    public class User : IdentityUser
    {    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? TestId { get; set; }
        public Test Test { get; set; }       
        public ICollection<Document> Documents { get; set; } = new List<Document>();
   
    }
}

