using Core.Entities;
using Application.IServices;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserOrganizer : IUserManager
    {
        public UserOrganizer(UserManager<User> userManager)
        {
            this.UserManager = userManager;

        }

        public UserManager<User> UserManager { get; }

        public Task<IdentityResult> AddToRoleAsync(User user, string role)
        {
            return UserManager.AddToRoleAsync(user, role);
        }

        public Task<IdentityResult> CreateAsync(User user, string password)
        {
            return UserManager.CreateAsync(user, password);

        }

    }
    
}
