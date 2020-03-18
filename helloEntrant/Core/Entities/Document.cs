using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
