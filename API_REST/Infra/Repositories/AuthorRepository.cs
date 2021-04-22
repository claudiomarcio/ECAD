using Domain.Models.Entities;
using Infra.EntityConfiguration;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace Infra.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        private readonly ApplicationDbContext _contex;
        public AuthorRepository(ApplicationDbContext contex) : base(contex)
          => _contex = contex;             
    }
}
