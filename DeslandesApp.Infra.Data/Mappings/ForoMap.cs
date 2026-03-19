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
            builder.ToTable("Foro");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NomeForo)
                .IsRequired()
                .HasMaxLength(200);

            // 🔒 Evita foro duplicado
            builder.HasIndex(x => x.NomeForo)
                .IsUnique();

            // 🔗 1 Foro -> N Varas
            builder.HasMany(x => x.Varas)
                .WithOne(x => x.Foro)
                .HasForeignKey(x => x.ForoId)
                .OnDelete(DeleteBehavior.Restrict); // 🔥 evita deletar foro com vara
        }
    }
}