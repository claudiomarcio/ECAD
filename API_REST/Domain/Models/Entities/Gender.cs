using System.Collections.Generic;

namespace Domain.Models.Entities
{
    public class Gender
    {
        public int CodGender { get; set; }
        public string Name { get; set; }        
        public List<Music> Musics { get; set; }
    }   
}