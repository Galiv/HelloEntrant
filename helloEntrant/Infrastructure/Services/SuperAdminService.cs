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

namespace Infrastructure.Services
{
    public class SuperAdminService : ISuperAdminService
    {
        UserManager<User> userManager;
        SignInManager<User> signInManager;
        helloEntrantContex dbContext;

        public SuperAdminService(UserManager<User> userManager, SignInManager<User> signInManager, helloEntrantContex dbContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.dbContext = dbContext;
        }

        public List<University> GetUniversities()
        {
            var unis = (from uni in dbContext.Universities
                        join user in dbContext.Users 
                        on uni.UserId equals user.Id
                        select new University()
                        {Name = uni.Name, User = user}).ToList();

            return unis;
        }

        public async Task<bool> AddNewUniversity(AddUniRequest request)
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

            await dbContext.Universities.AddAsync(university);
            var dbSuccess = await dbContext.SaveChangesAsync();

            return dbSuccess == 1;
        }

        



    }
}
