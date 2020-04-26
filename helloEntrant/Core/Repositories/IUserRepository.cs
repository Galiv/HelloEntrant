using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IUserRepository:IRepository<User>
    {
      Task<User> getUserWithUniversity(string userId);

      Task<User> GetUser(string email);
    }
}
