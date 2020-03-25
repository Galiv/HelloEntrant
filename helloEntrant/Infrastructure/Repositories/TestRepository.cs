using Core.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class TestRepository: Repository<Test>, ITestRepository
    {
        public TestRepository(helloEntrantContex contex) : base(contex)
        {

        }    
    }
}
