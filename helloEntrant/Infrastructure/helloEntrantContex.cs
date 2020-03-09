using Core.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class helloEntrantContex:IdentityDbContext<User>
    {
        public helloEntrantContex(DbContextOptions<helloEntrantContex> options):base (options)
        {
                
        }
    }
}
