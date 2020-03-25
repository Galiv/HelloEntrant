using Core.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class UniversityRepository: Repository<University>, IUniversityRepository
    {
        public UniversityRepository(helloEntrantContex contex) : base(contex)
        {

        }
    }
}
