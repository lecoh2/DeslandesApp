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
    internal class ProcessoEtiquetaMap : IEntityTypeConfiguration<ProcessoEtiqueta>
    {
        public void Configure(EntityTypeBuilder<ProcessoEtiqueta> builder)
        {
            builder.ToTable("PROCESSOETIQUETA");

            builder.HasKey(x => new { x.ProcessoId, x.EtiquetaId });

            builder.Property(x => x.ProcessoId)
                   .HasColumnName("PROCESSOID");

            builder.Property(x => x.EtiquetaId)
                   .HasColumnName("ETIQUETAID");

            builder.HasOne(x => x.Processo)
                   .WithMany(x => x.ProcessoEtiquetas)
                   .HasForeignKey(x => x.ProcessoId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_PROCESSOAETIQUETA_PROCESSO");

            builder.HasOne(x => x.Etiqueta)
                   .WithMany(x => x.ProcessoEtiquetas)
                   .HasForeignKey(x => x.EtiquetaId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_PROCSSOETIQUETA_PROCESSO");
        }
    }
}