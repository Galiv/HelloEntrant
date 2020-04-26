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

namespace ApplicationTest.AdministratorTests
{
    public class GetUniversityIdTests
    {
        [Fact]

        public async void GetUniversityId_ShouldReturnValidValues()
        {
            //arrange
            List<User> users = new List<User>
            {
                new User {Id = "1", Email = "email" },
                new User {Id = "2", Email = "secretEmail" }
            };

            List<University> universities = new List<University>
            {
                new University{UserId = "1", UniversityId = 1, User = users[0]},
                new University{UserId = "2", UniversityId = 2, User = users[1]}                
            };
           


            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var mockUnitOfWork = fixture.Freeze<Mock<IUnitOfWork>>();
            mockUnitOfWork.Setup(unit => unit.UniversityRepository.getAllWithUsers()).ReturnsAsync(universities);

            var administratorService = fixture.Create<AdministratorService>();

            //Act
            var result = await administratorService.GetUniversityId(users[0].Email);

            //assert
            Assert.True(result == 1);

        }

    }
}
