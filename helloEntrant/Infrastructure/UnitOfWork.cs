using Core;
using Core.Repositories;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public helloEntrantContex _db { get; private set; }

        private Lazy<IUserRepository> userRepository;
        private Lazy<IUniversityRepository> universityRepository;
        private Lazy<ITestRepository> testRepository;
        private Lazy<ISpecialityRepository> specialityRepository;
        private Lazy<IFacultyRepository> facultyRepository;
        private Lazy<IDocumentRepository> documentRepository;
        private Lazy<IApplicationRepository> applicationRepository;

        public IUserRepository UserRepository
        {
            get
            {
                return this.userRepository.Value;
            }
        }

        public IUniversityRepository UniversityRepository
        {
            get
            {
                return this.universityRepository.Value;
            }
        }

        public ITestRepository TestRepository
        {
            get
            {
                return this.testRepository.Value;
            }
        }

        public ISpecialityRepository SpecialityRepository
        {
            get
            {
                return this.specialityRepository.Value;
            }
        }

        public IFacultyRepository FacultyRepository
        {
            get
            {
                return this.facultyRepository.Value;
            }
        }

        public IDocumentRepository DocumentRepository
        {
            get
            {
                return this.documentRepository.Value;
            }
        }

        public IApplicationRepository ApplicationRepository
        {
            get
            {
                return this.applicationRepository.Value;
            }
        }


        public UnitOfWork(helloEntrantContex db)
        {
            _db = db;

            this.userRepository = new Lazy<IUserRepository>(() => new UserRepository(_db));
            this.universityRepository = new Lazy<IUniversityRepository>(() => new UniversityRepository(_db));
            this.testRepository = new Lazy<ITestRepository>(() => new TestRepository(_db));
            this.specialityRepository = new Lazy<ISpecialityRepository>(() => new SpecialityRepository(_db));
            this.facultyRepository = new Lazy<IFacultyRepository>(() => new FacultyRepository(_db));
            this.documentRepository = new Lazy<IDocumentRepository>(() => new DocumentRepository(_db));
            this.applicationRepository = new Lazy<IApplicationRepository>(() => new ApplicationRepository(_db));

            //додай решту
        }

        public async Task Commit()
        {
            await _db.SaveChangesAsync();
        }
    }
}
