using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Speciality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BudgetPlace { get; set; }
        public int PaidPlace { get; set; }
        public string testNeeded1 { get; set; }
        public string testNeeded2 { get; set; }
        public string testNeeded3 { get; set; }
    }
}
