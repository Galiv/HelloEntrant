using Application.DTOs.User;
using Application.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Core.Entities;
using Core;

namespace Infrastructure.Services
{
    public class UserService: IUserService
    {
        UserManager<User> userManager;

        private IUnitOfWork unitOfWork;

        public UserService(UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
        }

        public Task AddTests(UserProfile request)
        {
            throw new NotImplementedException();
        }

        public async Task<UserProfile> GetUserInfo(string email)
        {
            var user = await unitOfWork.UserRepository.GetUser(email);

            UserProfile userProfile = new UserProfile
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                City = user.City,
                DateOfBirth = user.DateOfBirth
               
            };

            return userProfile;

        }
        public async Task UpdateUserInfo(UserProfile request)
        {
            var user = await userManager.FindByEmailAsync(request.Email);

            if (user != null)
            {
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;             
                user.DateOfBirth = request.DateOfBirth;              
                user.City = request.City;

                await userManager.UpdateAsync(user);
            }
            
        }

        //public async Task AddTests(UserProfile request)
        //{
        //    var user = await userManager.FindByEmailAsync(request.Email);

        //    if (user != null)
        //    {
                

        //        await userManager.UpdateAsync(user);
        //    }

        //}
    }
}
