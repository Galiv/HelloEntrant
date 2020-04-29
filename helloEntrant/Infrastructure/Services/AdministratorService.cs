using Application.DTOs;
using Application.IServices;
using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Application.DTOs.Administrator;

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

        public async Task<List<Faculty>> GetFaculties(int UniversityId)
        {
            var faculties = (from f in await unitOfWork.FacultyRepository.GetAllAsync()
                             where f.UniversityId == UniversityId
                             select f
                             ).ToList<Faculty>();
            return faculties;

        }

        public async Task<int> GetUniversityId (string email)
        {
            var universityId = (from u in await unitOfWork.UniversityRepository.getAllWithUsers()
                                where u.User.Email == email
                                select u
                                ).ToList();
            return universityId[0].UniversityId;                                
        }



        public async Task CreateSpeciality (CreateSpeciality request)
        {
            var faculty = unitOfWork.SpecialityRepository.GetFaculty(request.FucaltyName);

            Speciality speciality = new Speciality
            {
                Name = request.SpecialityName,
                Description = request.Description,
                BudgetPlaceNumber = request.BudgetPlaceNumber,
                PaidPlaceNumber = request.PaidPlaceNumber,
                testNeeded1 = request.TestNeeded1,
                testNeeded2 = request.TestNeeded2,
                testNeeded3 = request.TestNeeded3,
                Faculty = faculty,
                FacultyId = faculty.FacultyId               
            };

            await unitOfWork.SpecialityRepository.CreateAsync(speciality);
            await unitOfWork.Commit();

        }

        public async Task<CurrentUniversityAndFacultiesModel> GetUniversityAsync(int universityId)
        {
            var university = await unitOfWork.UniversityRepository.GetAsync(universityId);

            var currentUniAndFaculties = new CurrentUniversityAndFacultiesModel();

            if (university != null)
            {
                currentUniAndFaculties.CurrentUniversity = university;

                var faculties = unitOfWork.FacultyRepository.GetAllFacultiesWithUniversityId(universityId).Result;

                currentUniAndFaculties.Faculties = faculties;

                return currentUniAndFaculties;
            }

            return null;
        }

        public async Task<CurrentFacultyAndSpecialitiesModel> GetFacultyAsync(int facultyId)
        {
            var faculty = await unitOfWork.FacultyRepository.GetAsync(facultyId);

            var currentFacultyAndSpecialities = new CurrentFacultyAndSpecialitiesModel();

            if (faculty != null)
            {
                currentFacultyAndSpecialities.CurrentFaculty = faculty;

                var specialities = unitOfWork.SpecialityRepository.GetAllSpecialitiesWithFacultyId(facultyId).Result;

                currentFacultyAndSpecialities.Specialities = specialities;

                var university = await unitOfWork.UniversityRepository.GetUniversityWithId(faculty.UniversityId);

                currentFacultyAndSpecialities.FacultyAdminId = university.UserId;

                return currentFacultyAndSpecialities;
            }

            return null;
        }


    }
}
