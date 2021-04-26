using Domain.Models.Entities;
using Domain.Interfaces.Repositories.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Repository
{
    public interface IMusicRepository : IRepositoryBase<Music>
    {
        Music UpdateMusic(Music music);
    }
}
