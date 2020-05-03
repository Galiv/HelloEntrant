using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ApplicationRepository : Repository<Core.Entities.Application>, IApplicationRepository
    {
        public ApplicationRepository(helloEntrantContex contex) : base(contex)
        {

        }
        public Task<List<Core.Entities.Application>> GetAllApplicationsByUserId(string userId)
        {
            return this.db.Applications
                .Where(a => a.UserId == userId).ToListAsync();
        }

        public Task<List<Core.Entities.Application>> GetAllApplicationsOfSpeciality (int specialityId)
        {
            return this.db.Applications
                .Where(a => a.SpecialityId == specialityId)
                .Include(a => a.User)
                .ThenInclude(u => u.Test).ToListAsync();
        }
    }
}
