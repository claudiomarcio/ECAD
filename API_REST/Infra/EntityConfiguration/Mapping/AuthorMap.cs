
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Entities;

namespace Infra.EntityConfiguration.Mapping
{
    public class AuthorMap : IEntityTypeConfiguration<Author>
     {
        public void Configure(EntityTypeBuilder<Author> builder)
        {         
            {
                builder.ToTable("Author");
                builder.HasKey(x => x.CodAuthor);
                builder.Property(x => x.CodAuthor).ValueGeneratedOnAdd();

            }
        }        
    }
}
