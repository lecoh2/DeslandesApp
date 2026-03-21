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
    public class GrupoAtendimentoEtiquetaMap : IEntityTypeConfiguration<GrupoAtendimentoEtiqueta>
    {
        public void Configure(EntityTypeBuilder<GrupoAtendimentoEtiqueta> builder)
        {
            builder.ToTable("GRUPOATENDIMENTOETIQUETA");

            builder.HasKey(x => new { x.AtendimentoId, x.EtiquetaId });

            builder.Property(x => x.AtendimentoId)
                   .HasColumnName("ATENDIMENTOID");

            builder.Property(x => x.EtiquetaId)
                   .HasColumnName("ETIQUETAID");

            builder.HasOne(x => x.Atendimento)
                   .WithMany(x => x.GrupoEtiquetas)
                   .HasForeignKey(x => x.AtendimentoId);

            builder.HasOne(x => x.Etiqueta)
                   .WithMany()
                   .HasForeignKey(x => x.EtiquetaId);
        }
    }
}
