using AutoFixture;
using AutoFixture.AutoMoq;
using Core;
using Core.Entities;
using Infrastructure.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ApplicationTest.SuperAdminServiceTests
{
    public class GetUniversitiesTests
    {
        [Fact]
        
        public async void GetUniversities_ShouldReturnValidValues()
        {
            //arrange
            List<University> universities = new List<University>
            {
                new University{UserId = "1", Name = "Uni1"},
                new University{UserId = "2", Name = "Uni2"}
            };
            List<User> users = new List<User>
            {
                new User {Id = "2" }
            };


            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var mockUnitOfWork = fixture.Freeze<Mock<IUnitOfWork>>();
            mockUnitOfWork.Setup(unit => unit.UniversityRepository.GetAllAsync()).ReturnsAsync(universities);
            mockUnitOfWork.Setup(unit => unit.UserRepository.GetAllAsync()).ReturnsAsync(users);
            var superAdminService = fixture.Create<SuperAdminService>();

            //act

            var result = await superAdminService.GetUniversities();

            //assert
            Assert.True(result[0].Name == "Uni2");

        }
    }
}
