using AutoFixture;
using AutoFixture.AutoMoq;
using Core;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ApplicationTest.AdministratorTests
{
    public class GetFacultiesTests
    {
        [Fact]

        public async void GetFaculties_ShouldReturnValidValues()
        {

            //Arrange
            List<Faculty> faculties = new List<Faculty>
            {
                new Faculty{Name = "Fac1", UniversityId = 1},
                new Faculty{Name = "Fac2", UniversityId = 1}
            };



            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var mockUnitOfWork = fixture.Freeze<Mock<IUnitOfWork>>();
            mockUnitOfWork.Setup(x => x.FacultyRepository.GetAllAsync()).ReturnsAsync(faculties);

            var administratorService = fixture.Create<AdministratorService>();

            //Act
            var result = await administratorService.GetFaculties(1);

            //assert
            Assert.True(result[0].Name == "Fac1");

            



        }
    }
}
