using Core.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class FacultyRepository: Repository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(helloEntrantContex contex) : base(contex)
        {

        }
    }
}
