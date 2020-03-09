using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class SignInRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
