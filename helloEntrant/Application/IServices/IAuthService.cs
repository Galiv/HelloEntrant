using Application.DTOs;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IAuthService
    {
        Task<SignInResult> SignIn(SignInRequest model);
        Task SignOut();
        Task<IdentityResult> Register(RegisterRequest model);
        Task<User> FindByNameAsync(string name);
    }
}
