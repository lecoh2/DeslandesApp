using DeslandesApp.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Infra.Data.Mappings
{
    public class ForoMap : IEntityTypeConfiguration<Foro>
    {
        public void Configure(EntityTypeBuilder<Foro> builder)
        {
            builder.ToTable("FORO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NomeForo)
                .HasColumnName("NOMEFORO")
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}