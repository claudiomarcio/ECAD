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
    public class GenderRepository : RepositoryBase<Gender>, IGenderRepository
    {
        private readonly ApplicationDbContext _contex;
        public GenderRepository(ApplicationDbContext contex) : base(contex)
          => _contex = contex;             
    }
}
