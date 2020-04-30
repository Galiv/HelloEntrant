using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Speciality
    {
        public int SpecialityId { get; set; }
        public string Name { get; set; }
        public int BudgetPlaceNumber { get; set; }
        public int PaidPlaceNumber { get; set; }
        public string Description { get; set; }

        //тут треба поміти тест на велику букву
        public string testNeeded1 { get; set; }
        public string testNeeded2 { get; set; }
        public string testNeeded3 { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        public List<string> GetRequiredTest()
        {
            var requiredTest = new List<string>
            {
                testNeeded1,
                testNeeded2
            };

            if (!string.IsNullOrWhiteSpace(testNeeded3)) requiredTest.Add(testNeeded3);

            return requiredTest;
        }
    }
}
