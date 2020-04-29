using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UniversityRepository: Repository<University>, IUniversityRepository
    {
        public UniversityRepository(helloEntrantContex contex) : base(contex)
        {

        }
        public Task<List<University>> getAllWithUsers()
        {
            return this.db.Universities.Include(u => u.User).ToListAsync();
        }

        public Task<University> GetUniversityWithId(int universityId)
        {
            return this.db.Universities.FirstOrDefaultAsync(uni => uni.UniversityId == universityId);
        }
    }
}
