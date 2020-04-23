using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.User
{
    public class UserProfile
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<TestHelper> testHelpers = new List<TestHelper>()
        {
            new TestHelper(),
            new TestHelper(),
            new TestHelper(),
            new TestHelper()
        };
}
    public class TestHelper
    {
        public string Name { get; set; }
        public string Mark { get; set; }

        
    }
}
