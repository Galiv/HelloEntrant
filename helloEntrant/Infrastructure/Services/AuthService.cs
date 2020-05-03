using Application.DTOs;
using Application.IServices;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
   public class AuthService:IAuthService {

        UserManager<User> _usermanager;
        RoleManager<IdentityRole> _rolemanager;
        SignInManager<User> _signinmanager;

        public AuthService(UserManager<User> usermanager, RoleManager<IdentityRole> rolemanager,
            SignInManager<User> signinmanager)
        {
            _usermanager = usermanager;
            _rolemanager = rolemanager;
            _signinmanager = signinmanager;
        }

        public async Task SignOut()
        {
            await _signinmanager.SignOutAsync();
        }

        public async Task<SignInResult> SignIn(SignInRequest model)
        {
            //role = _rolemanager.
           return await _signinmanager.PasswordSignInAsync(model.email, model.password, false, false);
        }

        public async Task<IdentityResult> Register(RegisterRequest model)
        {
            User user = new User();
            user.Email = model.email;
            user.UserName = model.email;
            

            IdentityResult result = await _usermanager.CreateAsync(user, model.password);
            if (result.Succeeded)
            {
                await _usermanager.AddToRoleAsync(user, "User");
                await _signinmanager.PasswordSignInAsync(model.email, model.password, false, false);

            }



            return result;

        }

        public async Task<User> FindByNameAsync(string name)
        {
            return await _usermanager.FindByNameAsync(name);
        }
    }
}
