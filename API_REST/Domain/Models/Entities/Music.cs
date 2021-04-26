using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models.Entities
{
    public class Music
    {
        public int CodMusic { get; set; }
        public int CodGender { get; set; }
        public int CodAuthor { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Author Author { get; set; }

        [NotMapped]
        public string GenderName { get; set; }
        [NotMapped]
        public string AuthorName { get; set; }
        
    }
}
