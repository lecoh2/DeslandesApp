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
    public class JuizoMap : IEntityTypeConfiguration<Juizo>
    {
        public void Configure(EntityTypeBuilder<Juizo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NomeJuizo)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasMany(x => x.Varas)
                .WithOne(x => x.Juizo)
                .HasForeignKey(x => x.JuizoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
