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
    public class GrupoSetoresMap : IEntityTypeConfiguration<GrupoSetores>
    {
        public void Configure(EntityTypeBuilder<GrupoSetores> builder)
        {
            builder.ToTable("GRUPOSETORES");

            builder.HasKey(g => new { g.IdUsuario, g.IdSetor });

            builder.HasOne(g => g.Usuario)
                   .WithMany(u => u.GrupoSetores)
                   .HasForeignKey(g => g.IdUsuario)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(g => g.Setor)
                   .WithMany(s => s.GrupoSetores)
                   .HasForeignKey(g => g.IdSetor)
                   .OnDelete(DeleteBehavior.Restrict);

            //builder.HasOne(g => g.Nivel)

            // .WithMany(n => n.GrupoAcessos)
            // .HasForeignKey(g => g.IdNivel)
            // .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
