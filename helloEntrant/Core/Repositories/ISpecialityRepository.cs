using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ISpecialityRepository: IRepository<Speciality>
    {
       Faculty GetFaculty(string faculty);
       Task<List<Speciality>> GetAllSpecialitiesWithFacultyId(int facultyId);
    }
}
