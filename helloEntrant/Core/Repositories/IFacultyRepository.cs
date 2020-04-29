using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IFacultyRepository: IRepository<Faculty>
    {
        Task<List<Faculty>> GetAllFacultiesWithUniversityId(int universityId);
    }
}
