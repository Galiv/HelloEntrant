using Core.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SpecialityRepository: Repository<Speciality>, ISpecialityRepository
    {
        public SpecialityRepository(helloEntrantContex contex) : base(contex)
        {

        }
        public Faculty GetFaculty(string faculty)
        {
            return this.db.Faculties.Where(f => f.Name == faculty).FirstOrDefault();
        }

        public Task<List<Speciality>> GetAllSpecialitiesWithFacultyId(int facultyId)
        {
            return this.db.Specialities.Where(f => f.FacultyId == facultyId).ToListAsync();
        }
    }
}
