using Application.DTOs;
using Application.IServices;
using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AdministratorService: IAdministratorService
    {
        private IUnitOfWork unitOfWork;

        public AdministratorService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task CreateFaculty (CreateFaculty request)
        {
            var user = await unitOfWork.UserRepository.getUserWithUniversity(request.UserId);
                       
            Faculty faculty = new Faculty
            {
                Name = request.FacultyName,
                Address = request.Address,
                UniversityId = user.University.UniversityId
            };

            await unitOfWork.FacultyRepository.CreateAsync(faculty);
            await unitOfWork.Commit();
        }
    }
}
