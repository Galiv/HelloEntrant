using Core.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class SpecialityRepository: Repository<Speciality>, ISpecialityRepository
    {
        public SpecialityRepository(helloEntrantContex contex) : base(contex)
        {

        }
    }
}
