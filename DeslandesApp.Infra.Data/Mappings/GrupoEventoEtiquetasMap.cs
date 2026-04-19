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
    public class GrupoEventoEtiquetasMap : IEntityTypeConfiguration<GrupoEventoEtiquetas>
    {
        public void Configure(EntityTypeBuilder<GrupoEventoEtiquetas> builder)
        {
            builder.ToTable("GRUPOEVENTOETIQUETAS");

            builder.HasKey(x => new { x.EventoId, x.EtiquetaId });

            builder.Property(x => x.EventoId)
                   .HasColumnName("EVENDOID");

            builder.Property(x => x.EtiquetaId)
                   .HasColumnName("ETIQUETAID");

            builder.HasOne(x => x.Evento)
                   .WithMany(x => x.GrupoEventoEtiquetas)
                   .HasForeignKey(x => x.EventoId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_EVENTOETIQUETA_EVENTO");

            builder.HasOne(x => x.Etiqueta)
                   .WithMany(x => x.GrupoEventoEtiquetas)
                   .HasForeignKey(x => x.EtiquetaId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_EVENTOETIQUETA_ETIQUETA");
        }
    }
}