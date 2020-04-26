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
    public class RemoveUniversityTests
    {
        [Fact]

        public async void RemoveUniversity_SaveChanges_ShouldInvokesOnce()
        {

            //Arrange
            List<University> universities = new List<University>
            {
                new University{UniversityId = 1, Name = "Uni1"},
                new University{UniversityId = 2, Name = "Uni2"}
            };

            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var mockUnitOfWork = fixture.Freeze<Mock<IUnitOfWork>>();
            mockUnitOfWork.Setup(unit => unit.UniversityRepository.GetAllAsync()).ReturnsAsync(universities);
            var superAdminService = fixture.Create<SuperAdminService>();

            //Act
            var result = superAdminService.RemoveUniversity(universities[0].UniversityId);

            //assert
            //Assert.True(universities[0].Name == "Uni2");
            mockUnitOfWork.Verify(unit => unit.Commit(), Times.Once);


        }
    }
}
