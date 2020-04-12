using Core.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

    }
}
