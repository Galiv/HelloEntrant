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
    public class GetRatingAsyncTests
    {
        [Fact]

        public async void GetRatingAsync_ShouldReturnValidValues()
        {
            //arrange

            Speciality speciality = new Speciality()
            {
                SpecialityId = 1
            };

            Test zno = new Test()
            {
                TestId = 1,
                
                Math = 190,
                English = 100,
                Biology = 130
            };

            User user = new User()
            {
                Id = "1",
                FirstName = "Andriy",
                LastName = "Galiv",
                TestId = 1,
                Test = zno
                
            };

            
            List<Core.Entities.Application> applications = new List<Core.Entities.Application>
            {
                new Core.Entities.Application { ApplicationId = 1, SpecialityId = 1, UserId = "1", User = user}//,
                //new Core.Entities.Application { ApplicationId = 2, SpecialityId = 1}
            };

            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var mockUnitOfWork = fixture.Freeze<Mock<IUnitOfWork>>();

            mockUnitOfWork.Setup(a => a.ApplicationRepository.GetAllApplicationsOfSpeciality(speciality.SpecialityId)).ReturnsAsync(applications);

            var administratorService = fixture.Create<AdministratorService>();

            //Act
            var result = await administratorService.GetRatingAsync(speciality.SpecialityId);

            //assert
            Assert.True(result[0].FirstName == "Andriy");



        }
    }
}
