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
    public class GrupoNiveisMap : IEntityTypeConfiguration<GrupoNiveis>
    {
        public void Configure(EntityTypeBuilder<GrupoNiveis> builder)
        {
            builder.ToTable("GRUPONIVEL");

            builder.HasKey(g => new { g.IdUsuario, g.IdNivel });

            builder.HasOne(g => g.Usuario)
                   .WithMany(u => u.GrupoNiveis)
                   .HasForeignKey(g => g.IdUsuario)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(g => g.Niveis)
                   .WithMany(s => s.GrupoNiveis)
                   .HasForeignKey(g => g.IdNivel)
                   .OnDelete(DeleteBehavior.Restrict);

            //builder.HasOne(g => g.Nivel)

            // .WithMany(n => n.GrupoAcessos)
            // .HasForeignKey(g => g.IdNivel)
            // .OnDelete(DeleteBehavior.Restrict);
        }
    }


}

