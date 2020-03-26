using Application.DTOs.SuperAdmin;
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
    public class CreatUniversityTests
    {
        [Fact]
        public async void CreateUniversity_ShouldInvokesOnce()
        {
            //arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var mockUnitOfWork = fixture.Freeze<Mock<IUnitOfWork>>();
            var superAdminService = fixture.Create<SuperAdminService>();
            //act

            await superAdminService.AddNewUniversity(fixture.Create<AddUniRequest>());

            //assert

            mockUnitOfWork.Verify(unit => unit.UniversityRepository.CreateAsync(It.IsAny<University>()),Times.Once);
        }

        [Fact]
        public async void CreateUniversity_SaveChanges_ShouldInvokesOnce()
        {
            //arrangem
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var mockUnitOfWork = fixture.Freeze<Mock<IUnitOfWork>>();
            var superAdminService = fixture.Create<SuperAdminService>();
            //act

            await superAdminService.AddNewUniversity(fixture.Create<AddUniRequest>());

            //assert

            mockUnitOfWork.Verify(unit => unit.Commit(), Times.Once);
        }

    }
}
