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

        public TestHelper testHelper1 { get; set; }

        public TestHelper testHelper2 { get; set; }
        public TestHelper testHelper3 { get; set; }
        public TestHelper testHelper4 { get; set; }

        //public List<TestHelper> testHelpers = new List<TestHelper>()
        //{
        //    new TestHelper(),
        //    new TestHelper(),
        //    new TestHelper(),
        //    new TestHelper()
        //};
    }
    public class TestHelper
    {
        public string Name { get; set; }
        public string Mark { get; set; }

        
    }
}
