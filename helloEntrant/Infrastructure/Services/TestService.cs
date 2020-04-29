using Application.DTOs.User;
using Application.IServices;
using Core;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TestService: ITestService
    {
        UserManager<User> userManager;

        private IUnitOfWork unitOfWork;

        public TestService (UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
        }

        public void MapTests(ref Test test, string name, double mark)
        {
            switch (name)
            {
                case "Math":
                    test.Math = mark;
                    break;
                case "Geography":
                    test.Geography = mark;
                    break;
                case "Ukrainian":
                    test.Ukrainian = mark;
                    break;
                case "History":
                    test.History = mark;
                    break;
                case "English":
                    test.English = mark;
                    break;
                case "Spanish":
                    test.Spanish = mark;
                    break;
                case "French":
                    test.French = mark;
                    break;
                case "German":
                    test.German = mark;
                    break;
                case "Biology":
                    test.Biology = mark;
                    break;
                case "Physics":
                    test.Physics = mark;
                    break;
                case "Chemistry":
                    test.Chemistry = mark;
                    break;
            }
        }

        

        public async Task SaveTests(UserProfile request, string username)
        {
            var user = await userManager.FindByNameAsync(username);

            var tests = new Test();

            tests.User = user;

            if (request.testHelper1 !=null)
            {
                MapTests(ref tests, request.testHelper1.Name, Convert.ToDouble(request.testHelper1.Mark));
            }
            if (request.testHelper2 != null)
            {
                MapTests(ref tests, request.testHelper2.Name, Convert.ToDouble(request.testHelper2.Mark));
            }
            if (request.testHelper3 != null)
            {
                MapTests(ref tests, request.testHelper3.Name, Convert.ToDouble(request.testHelper3.Mark));
            }
            if (request.testHelper4 != null)
            {
                MapTests(ref tests, request.testHelper4.Name, Convert.ToDouble(request.testHelper4.Mark));
            }


            user.Test = tests;
            user.TestId = tests.TestId;

            await unitOfWork.TestRepository.CreateAsync(tests);
            await unitOfWork.Commit();


        }
    }
}
