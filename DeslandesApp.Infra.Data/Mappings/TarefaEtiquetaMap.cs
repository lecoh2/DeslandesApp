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
    public class TarefaEtiquetaMap : IEntityTypeConfiguration<TarefaEtiqueta>
    {
        public void Configure(EntityTypeBuilder<TarefaEtiqueta> builder)
        {
            builder.ToTable("TAREFAETIQUETA");

            builder.HasKey(x => new { x.TarefaId, x.EtiquetaId });

            builder.Property(x => x.TarefaId)
                   .HasColumnName("TAREFAID");

            builder.Property(x => x.EtiquetaId)
                   .HasColumnName("ETIQUETAID");

            builder.HasOne(x => x.Tarefa)
                   .WithMany(x => x.TarefaEtiquetas)
                   .HasForeignKey(x => x.TarefaId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_TAREFAETIQUETA_TAREFA");

            builder.HasOne(x => x.Etiqueta)
                   .WithMany(x => x.TarefaEtiquetas)
                   .HasForeignKey(x => x.EtiquetaId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_TAREFAETIQUETA_ETIQUETA");
        }
    }
}