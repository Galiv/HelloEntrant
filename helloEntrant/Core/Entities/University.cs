using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class University
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }       
        public string Address { get; set; }
        public Document Document { get; set; }
        public int DocumentId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public ICollection<Faculty> Faculties { get; set; } = new List<Faculty>();

    }
}
