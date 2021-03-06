﻿using Application.DTOs;
using Application.DTOs.Administrator;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IAdministratorService
    {
        Task CreateFaculty(CreateFaculty request);
        Task<List<Faculty>> GetFaculties(int UniversityId);
        Task<int> GetUniversityId(string UserId);
        Task CreateSpeciality(CreateSpeciality request);
        Task<CurrentUniversityAndFacultiesModel> GetUniversityAsync(int universityId);
        Task<CurrentFacultyAndSpecialitiesModel> GetFacultyAsync(int facultyId);
        Task<List<UserRating>> GetRatingAsync(int specialityId);
    }
}
