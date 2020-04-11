using Application.DTOs;
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
    }
}
