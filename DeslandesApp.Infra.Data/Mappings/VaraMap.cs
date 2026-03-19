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
            builder.ToTable("Vara");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NomeVara)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Numero)
                .IsRequired();

            builder.Property(x => x.Tipo)
                .IsRequired()
                .HasMaxLength(100);

            // 🔍 Índice para busca rápida
            builder.HasIndex(x => x.ForoId);

            // 🔒 Evita duplicidade de vara dentro do mesmo foro
            builder.HasIndex(x => new { x.Numero, x.Tipo, x.ForoId })
                .IsUnique();

            // 🔗 1 Vara -> N Processos
            builder.HasMany(x => x.Processos)
                .WithOne(x => x.Vara)
                .HasForeignKey(x => x.VaraId)
                .OnDelete(DeleteBehavior.Restrict); // 🔥 evita apagar vara com processo
        }
    }
}