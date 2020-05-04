using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs.Administrator;
using AutoFixture;
using AutoFixture.AutoMoq;
using Core;
using Core.Entities;
using Infrastructure.Services;
using Moq;
using Xunit;

namespace ApplicationTest.AdministratorTests
{
    public class GetUniversityAsyncTests
    {
        [Fact]

        public async void GetUniversityAsync_ShouldReturnValidValues()
        {
            //arrange
            University university = new University()
            {
                UniversityId = 1,
                Name = "LNU"
            };

            List<Faculty> faculties = new List<Faculty>
            {
                new Faculty{Name = "Fac1", UniversityId = 1},
                new Faculty{Name = "Fac2", UniversityId = 1}
            };

            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var mockUnitOfWork = fixture.Freeze<Mock<IUnitOfWork>>();
            

            mockUnitOfWork.Setup(u => u.UniversityRepository.GetAsync(university.UniversityId)).ReturnsAsync(university);

            mockUnitOfWork.Setup(f => f.FacultyRepository.GetAllFacultiesWithUniversityId(university.UniversityId)).ReturnsAsync(faculties);
                       
            var administratorService = fixture.Create<AdministratorService>();
            //Act
            var result = await administratorService.GetUniversityAsync(university.UniversityId);

            //Assert

            Assert.True(result.CurrentUniversity.Name == "LNU");
        }

    }
}
