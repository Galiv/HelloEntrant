using Core.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class DocumentRepository: Repository<Document>, IDocumentRepository
    {
        public DocumentRepository(helloEntrantContex contex) : base(contex)
        {

        }
    }
}
