using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IAdministratorService
    {
        Task CreateFaculty(CreateFaculty request);
    }
}
