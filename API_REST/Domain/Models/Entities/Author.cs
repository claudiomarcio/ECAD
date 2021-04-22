using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class Author
    {    
        public int CodAuthor { get; set; }
        public string Name { get; set; }
        public List<Music> Musics { get; set; }
        public Category Category { get; set; }
    }
}
