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
    //додай ще тут

        
        public IUserRepository UserRepository
        {
            get
            {
                return this.userRepository.Value;
            }
        }


        public UnitOfWork(helloEntrantContex db)
        {
            _db = db;

            this.userRepository = new Lazy<IUserRepository>(() => new UserRepository(_db));

            //додай решту
        }

        public async Task Commit()
        {
            await _db.SaveChangesAsync();
        }
    }
}
