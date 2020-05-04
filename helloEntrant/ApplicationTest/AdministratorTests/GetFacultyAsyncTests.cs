using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using AutoFixture.AutoMoq;
using Core;
using Core.Entities;
using Infrastructure.Services;
using Moq;
using Xunit;

namespace ApplicationTest.AdministratorTests
{
    public class GetFacultyAsyncTests
    {
        [Fact]
        public async void GetFacultyAsync_ShouldReturnValidValues()
        {
            //arrange

            University university = new University()
            {
                UniversityId = 1,
                Name = "LNU",
                UserId = "user"
            };

            Faculty faculty = new Faculty()
            {
                FacultyId = 1,
                Name = "Fac1",
                UniversityId = 1

            };

            List<Speciality> specialities = new List<Speciality>
            {
                new Speciality{Name = "s1", FacultyId = 1},
                new Speciality{Name = "s2", FacultyId = 1}
            };

            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var mockUnitOfWork = fixture.Freeze<Mock<IUnitOfWork>>();


            mockUnitOfWork.Setup(u => u.FacultyRepository.GetAsync(faculty.FacultyId)).ReturnsAsync(faculty);
            mockUnitOfWork.Setup(f => f.SpecialityRepository.GetAllSpecialitiesWithFacultyId(faculty.FacultyId)).ReturnsAsync(specialities);
            mockUnitOfWork.Setup(u => u.UniversityRepository.GetUniversityWithId(university.UniversityId)).ReturnsAsync(university);

            var administratorService = fixture.Create<AdministratorService>();


            //Act
            var result = await administratorService.GetFacultyAsync(faculty.FacultyId);

            //Assert

            Assert.True(result.CurrentFaculty == faculty);
        }
        
    }
}
