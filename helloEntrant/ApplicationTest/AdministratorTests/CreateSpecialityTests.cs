using Application.DTOs.Administrator;
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
            };

         
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var specialityRepository = new Mock<ISpecialityRepository>();
            mockUnitOfWork.Setup(x => x.SpecialityRepository).Returns(specialityRepository.Object);
            specialityRepository.Setup(x => x.GetFaculty(It.IsAny<string>())).Returns(faculty);            

            var administratorService = new AdministratorService(mockUnitOfWork.Object);
            var createSpeciality = new CreateSpeciality()
            {
                SpecialityName = "la",
                Description = "la",
                BudgetPlaceNumber = 100,
                PaidPlaceNumber = 100,
                TestNeeded1 = "Math",
                TestNeeded2 = "English",
                TestNeeded3 = "German",
                FucaltyName = "Math"
            };

            //Act
            await administratorService.CreateSpeciality(createSpeciality);

            //assert
            mockUnitOfWork.Verify(x => x.SpecialityRepository.CreateAsync(It.IsAny<Speciality>()), Times.Once);
            





        }
    }
}
