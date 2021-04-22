using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class Music
    {
        public int CodMusic { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Author Author { get; set; }
    }
}
