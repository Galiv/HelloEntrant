using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository:Repository<User>,IUserRepository
    {
       public UserRepository(helloEntrantContex contex):base (contex)
        {
            
        }
        public Task<User> getUserWithUniversity (string userId)
        {
            return db.Users.Where(u => u.Id == userId).Include(u => u.University).FirstOrDefaultAsync();
        }

        public Task<User> GetUser (string email)
        {
            return db.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
        }
    }
}
