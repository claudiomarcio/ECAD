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
    public class MusicRepository : RepositoryBase<Music>, IMusicRepository
    {
        private readonly ApplicationDbContext _contex;
        public MusicRepository(ApplicationDbContext contex) : base(contex)
          => _contex = contex;      
        
        public Music UpdateMusic(Music music)
        {
            var model = this.GetById(music.CodMusic);
            model.Name = music.Name;
            model.CodGender = music.CodGender;
            model.CodAuthor = music.CodAuthor;
            this.Update(model);

            return music;

        }
    }
}
