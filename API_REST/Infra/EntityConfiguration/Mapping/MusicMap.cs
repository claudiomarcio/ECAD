
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Entities;

namespace Infra.EntityConfiguration.Mapping
{
    public class MusicMap : IEntityTypeConfiguration<Music>
    {
        public void Configure(EntityTypeBuilder<Music> builder)
        {
            {
                builder.ToTable("Music");            
                builder.HasKey(x => x.CodMusic);
                builder.Property(x => x.CodMusic).ValueGeneratedOnAdd();
            }
        }
    }
}
