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
    public class EtiquetaMap : IEntityTypeConfiguration<Etiqueta>
    {
        public void Configure(EntityTypeBuilder<Etiqueta> builder)
        {
            builder.ToTable("ETIQUETA");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Cor)
                .HasMaxLength(20);

            // =========================
            // 🔥 PROCESSOS
            // =========================
            builder.HasMany(x => x.GrupoEtiquetasProcessos)
                .WithOne(x => x.Etiqueta)
                .HasForeignKey(x => x.EtiquetaId)
                .OnDelete(DeleteBehavior.Cascade);

            // =========================
            // 🔥 ATENDIMENTOS
            // =========================
            builder.HasMany(x => x.GrupoEtiquetasAtendimentos)
                .WithOne(x => x.Etiqueta)
                .HasForeignKey(x => x.EtiquetaId)
                .OnDelete(DeleteBehavior.Cascade);

            // =========================
            // 🔥 CASOS
            // =========================
            builder.HasMany(x => x.GrupoEtiquetasCasos)
                .WithOne(x => x.Etiqueta)
                .HasForeignKey(x => x.EtiquetaId)
                .OnDelete(DeleteBehavior.Cascade);

            // =========================
            // 🔥 PESSOAS
            // =========================
            builder.HasMany(x => x.GrupoPessoasEtiquetas)
                .WithOne(x => x.Etiqueta)
                .HasForeignKey(x => x.EtiquetaId)
                .OnDelete(DeleteBehavior.Cascade);

            // =========================
            // 🔥 EVENTOS
            // =========================
            builder.HasMany(x => x.GrupoEventoEtiquetas)
                .WithOne(x => x.Etiqueta)
                .HasForeignKey(x => x.EtiquetaId)
                .OnDelete(DeleteBehavior.Cascade);

            // =========================
            // 🔥 TAREFAS
            // =========================
            builder.HasMany(x => x.GrupoTarefasEtiquetas)
                .WithOne(x => x.Etiqueta)
                .HasForeignKey(x => x.EtiquetaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
