using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IUnitOfWork
    {
        
        IUserRepository UserRepository { get; }
        IUniversityRepository UniversityRepository { get; }
        ITestRepository TestRepository { get; }
        ISpecialityRepository SpecialityRepository { get; }
        IFacultyRepository FacultyRepository { get; }
        IDocumentRepository DocumentRepository { get; }
        IApplicationRepository ApplicationRepository { get; }

        Task Commit();
    }

}
