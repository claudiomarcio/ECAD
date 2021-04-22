using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.EntityConfiguration.Mapping
{
    public class GenderMap : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            {
                builder.ToTable("Gender");
                builder.HasKey(x => x.CodGender);
                builder.Property(x => x.CodGender).ValueGeneratedOnAdd();
            }
        }
    }
}
