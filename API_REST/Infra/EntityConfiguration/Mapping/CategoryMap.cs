
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Entities;

namespace Infra.EntityConfiguration.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
     {
        public void Configure(EntityTypeBuilder<Category> builder)
        {         
            {
                builder.ToTable("Category");             
                builder.HasKey(x => x.CodCategory);
                builder.Property(x => x.CodCategory).ValueGeneratedOnAdd();
            }
        }

        
    }
}
