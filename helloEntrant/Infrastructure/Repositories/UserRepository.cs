using Core.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class UserRepository:Repository<User>,IUserRepository
    {
       public UserRepository(helloEntrantContex contex):base (contex)
        {

        }
    }
}
