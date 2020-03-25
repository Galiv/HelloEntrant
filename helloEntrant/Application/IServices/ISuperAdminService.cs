using Application.DTOs.SuperAdmin;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ISuperAdminService
    {
        Task AddNewUniversity(AddUniRequest request);

        Task<List<University>> GetUniversities();
    }
}
