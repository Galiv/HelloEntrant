using Core;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ApplicationTest.AdministratorTests
{
    public class CreateSpecialityTests
    {
        [Fact]
        public async void CreateSpeciality_ShouldInvokesOnce()
        {

            //arrange   

            var faculty = new Faculty
            {
                Name = "Math",
                FacultyId = 1
            };

            var speciality = new Speciality
            {
                Name = "la",
                Description = "la",
                BudgetPlaceNumber = 100,
                PaidPlaceNumber = 100,
                testNeeded1 = "Math",
                testNeeded2 = "English",
                testNeeded3 = "English",
                Faculty = faculty,
                FacultyId = faculty.FacultyId
            };

            

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var specialityRepository = new Mock<ISpecialityRepository>();


            specialityRepository.Setup(x => x.GetFaculty(It.IsAny<string>())).Returns(faculty);

            //var facultyRepository = new Mock<IFacultyRepository>();

            //userRepository.Setup(x => x.getUserWithUniversity(It.IsAny<string>())).ReturnsAsync(user);
            //mockUnitOfWork.Setup(x => x.UserRepository).Returns(userRepository.Object);
            //mockUnitOfWork.Setup(x => x.FacultyRepository).Returns(facultyRepository.Object);
            //var createFaculty = new Mock<CreateFaculty>();
            //var administratorService = new AdministratorService(mockUnitOfWork.Object);


            ////Act
            //await administratorService.CreateFaculty(faculty);
            ////assert
            //mockUnitOfWork.Verify(x => x.FacultyRepository.CreateAsync(It.IsAny<Faculty>()), Times.Once);



        }
    }
}
