using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }        
        public int DocumentId { get; set; }
        public Document Document { get; set; }
        public int UniversityId { get; set; }
        public University University { get; set; }
        public ICollection<Speciality> Specialities { get; set; } = new List<Speciality>();
    }
}
