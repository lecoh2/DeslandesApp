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
    public class VaraMap : IEntityTypeConfiguration<Vara>
    {
        public void Configure(EntityTypeBuilder<Vara> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NomeVara)
                .HasMaxLength(200);

            builder.HasOne(x => x.Juizo)
                .WithMany(x => x.Varas)
                .HasForeignKey(x => x.JuizoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Foros)
                .WithOne(x => x.Vara)
                .HasForeignKey(x => x.VaraId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}