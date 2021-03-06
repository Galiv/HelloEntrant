﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IUniversityRepository: IRepository<University>
    {
        Task<List<University>> getAllWithUsers();
        Task<University> GetUniversityWithId(int universityId);
    }
}
