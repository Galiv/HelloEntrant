using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Application.IServices;
using Application.DTOs.SuperAdmin;
using Core.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Core;

namespace Infrastructure.Services
{
    public class SuperAdminService : ISuperAdminService
    {
        UserManager<User> userManager;
        SignInManager<User> signInManager;
        private readonly IUnitOfWork unitOfWork;

        public SuperAdminService(UserManager<User> userManager, SignInManager<User> signInManager, IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<University>> GetUniversities()
        {
            var unis = (from uni in await unitOfWork.UniversityRepository.GetAllAsync()
                        join user in await unitOfWork.UserRepository.GetAllAsync()
                        on uni.UserId equals user.Id
                        select new University()
                        {Name = uni.Name, User = user}).ToList();

            return unis;
        }

        public async Task AddNewUniversity(AddUniRequest request)
        {
            User user = new User
            {
                Email = request.Email,
                UserName = request.Email
            };

            var success = await userManager.CreateAsync(user, request.Password);

            if (success.Succeeded == true)
            {
                await userManager.AddToRoleAsync(user, "Administrator");
                await signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);
            }

            University university = new University()
            {
                Name = request.UniversityName,
                UserId = user.Id
            };

            await unitOfWork.UniversityRepository.CreateAsync(university);
            await unitOfWork.Commit();

            //return dbSuccess == 1;
        }

        



    }
}
