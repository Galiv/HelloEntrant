using Core.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class FacultyRepository: Repository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(helloEntrantContex contex) : base(contex)
        {

        }
        public Task<List<Faculty>> GetAllFacultiesWithUniversityId(int universityId)
        {
            return this.db.Faculties
                .Where(f => f.UniversityId == universityId).ToListAsync();
        }
    }

}
