using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ApplicationRepository : Repository<Core.Entities.Application>, IApplicationRepository
    {
        public ApplicationRepository(helloEntrantContex contex) : base(contex)
        {

        }
    }
}
