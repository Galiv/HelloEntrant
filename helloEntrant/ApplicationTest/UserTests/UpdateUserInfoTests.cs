using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.User;
using Application.IServices;
using AutoFixture;
using AutoFixture.AutoMoq;
using Core;
using Core.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace ApplicationTest.UserTests
{
    public class UpdateUserInfoTests
    {

        //[Fact]
        //public async void UpdateUserInfo_ShouldInvokesOnce()
        //{
        //    DateTime date = new DateTime(10, 10, 10);
        //    string email = "gal@gmail.com";

        //    var user = new User
        //    {
        //        FirstName = "Andriy",
        //        LastName = "Galiv",
        //        DateOfBirth = date,
        //        City = "Kolomyya",
        //        Email = "gal@gmail.com"
        //    };

        //    var fixture = new Fixture().Customize(new AutoMoqCustomization());
        //    var mockUnitOfWork = new Mock<IUnitOfWork>();

        //    var userManager = new Mock<UserManager<User>>();

        //    userManager.Setup(u => u.FindByEmailAsync(email)).ReturnsAsync(user);

        //    var userService = fixture.Create<UserService>();

        //    var userProfile = new UserProfile()
        //    {
        //        FirstName = "Andriy",
        //        LastName = "Galiv",
        //        DateOfBirth = date,
        //        City = "Kolomyya"
        //    };

        //    userManager.Setup(u => u.UpdateAsync(user));

        //    //Act
        //    var result = userService.UpdateUserInfo(userProfile);

        //    //assert
        //    //userManager.Verify(x => x.UpdateAsync(It.IsAny<User>()), Times.Once);
        //    //mockUnitOfWork.Verify(x => x.SpecialityRepository.CreateAsync(It.IsAny<Speciality>()), Times.Once);

       // }
    }
}
