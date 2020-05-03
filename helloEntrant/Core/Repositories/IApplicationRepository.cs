using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IApplicationRepository: IRepository<Application>
    {
        Task<List<Application>> GetAllApplicationsByUserId(string userId);

        Task<List<Core.Entities.Application>> GetAllApplicationsOfSpeciality(int specialityId);
    }    
}
