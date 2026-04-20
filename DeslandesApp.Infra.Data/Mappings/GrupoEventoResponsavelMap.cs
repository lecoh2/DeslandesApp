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
    public class GrupoEventoResponsavelMap : IEntityTypeConfiguration<GrupoEventoResponsavel>
    {
        public void Configure(EntityTypeBuilder<GrupoEventoResponsavel> builder)
        {
            builder.ToTable("GRUPOEVENTORESPONSAVEL");

            builder.HasKey(x => new { x.EventoId, x.UsuarioId});

            builder.Property(x => x.EventoId).HasColumnName("EVENTOID");
            builder.Property(x => x.UsuarioId).HasColumnName("USUARIOID");

            builder.HasOne(x => x.Evento)
                   .WithMany(x => x.GrupoEventoResponsaveis)
                   .HasForeignKey(x => x.EventoId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Usuario)
                   .WithMany()
                   .HasForeignKey(x => x.UsuarioId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
   
}
