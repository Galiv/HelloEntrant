using Application.DTOs.User;
using Application.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Core.Entities;
using Core;
using System.Reflection;

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

            var tests = await unitOfWork.TestRepository.GetAsync(Convert.ToInt32(user.TestId));

            UserProfile userProfile = new UserProfile
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                City = user.City,
                DateOfBirth = user.DateOfBirth               
            };
            if(tests != null)
            {
                int i = 0;

                PropertyInfo[] properties = typeof(Test).GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    var p = property.GetValue(tests);
                    if (p != null)
                    {
                        var n = property.Name;
                        switch (i)
                        {
                            case 0:
                                userProfile.testHelper1 = new TestHelper();
                                userProfile.testHelper1.Name = n;
                                userProfile.testHelper1.Mark = Convert.ToString(p);
                                i++;
                                break;
                            case 1:
                                userProfile.testHelper2 = new TestHelper();
                                userProfile.testHelper2.Name = n;
                                userProfile.testHelper2.Mark = Convert.ToString(p);
                                i++;
                                break;
                            case 2:
                                userProfile.testHelper3 = new TestHelper();
                                userProfile.testHelper3.Name = n;
                                userProfile.testHelper3.Mark = Convert.ToString(p);
                                i++;
                                break;
                            case 3:
                                userProfile.testHelper4 = new TestHelper();
                                userProfile.testHelper4.Name = n;
                                userProfile.testHelper4.Mark = Convert.ToString(p);
                                i++;
                                break;
                        }
                    }                    
                    
                }
            }

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
