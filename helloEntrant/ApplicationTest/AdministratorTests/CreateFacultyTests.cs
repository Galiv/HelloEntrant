using Application.DTOs;
using Application.IServices;
using AutoFixture;
using AutoFixture.AutoMoq;
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
    public class CreateFacultyTests
    {
        [Fact]
        public async void CreateFaculty_ShouldInvokesOnce()
        {

            //arrange   
            var user = new User
            {
                University = new University
                {
                    UniversityId = 1
                }
            };

            var faculty = new CreateFaculty
            {
                UserId = "la",
                FacultyName = "la",
                Address = "la"
            };

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var userRepository = new Mock<IUserRepository>();
            var facultyRepository = new Mock<IFacultyRepository>();

            userRepository.Setup(x => x.getUserWithUniversity(It.IsAny<string>())).ReturnsAsync(user);
            mockUnitOfWork.Setup(x => x.UserRepository).Returns(userRepository.Object);
            mockUnitOfWork.Setup(x => x.FacultyRepository).Returns(facultyRepository.Object);
            var createFaculty = new Mock<CreateFaculty>();
            var administratorService = new AdministratorService(mockUnitOfWork.Object);        
           

            //Act
            await administratorService.CreateFaculty(faculty);
            //assert
            mockUnitOfWork.Verify(x => x.FacultyRepository.CreateAsync(It.IsAny<Faculty>()), Times.Once);
          

            
        }

        [Fact]
        public async void CreateFaculty_SaveChanges_ShouldInvokesOnce()
        {
            //arrange   
            var user = new User
            {
                University = new University
                {
                    UniversityId = 2
                }
            };

            var faculty = new CreateFaculty
            {
                UserId = "2",
                FacultyName = "lnu",
                Address = "Franka"
            };

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var userRepository = new Mock<IUserRepository>();
            var facultyRepository = new Mock<IFacultyRepository>();

            userRepository.Setup(x => x.getUserWithUniversity(It.IsAny<string>())).ReturnsAsync(user);
            mockUnitOfWork.Setup(x => x.UserRepository).Returns(userRepository.Object);
            mockUnitOfWork.Setup(x => x.FacultyRepository).Returns(facultyRepository.Object);
            var createFaculty = new Mock<CreateFaculty>();
            var administratorService = new AdministratorService(mockUnitOfWork.Object);

            //Act
            await administratorService.CreateFaculty(faculty);

            //Assert
            mockUnitOfWork.Verify(x => x.Commit(), Times.Once);

        }
    }
}
