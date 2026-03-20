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
    public class ListaTarefaMap : IEntityTypeConfiguration<ListaTarefa>
    {
        public void Configure(EntityTypeBuilder<ListaTarefa> builder)
        {
            builder.ToTable("LISTATAREFA");

            // 🔑 PK
            builder.HasKey(x => x.Id);

            // 🔹 Campos básicos
            builder.Property(x => x.Prioridade)
                   .HasColumnName("PRIORIDADE")
                   .IsRequired();

            builder.Property(x => x.ResponsavelId)
                   .HasColumnName("RESPONSAVELID");

            builder.Property(x => x.VinculoId)
                   .HasColumnName("VINCULOID")
                   .IsRequired();

            builder.Property(x => x.TipoVinculo)
                   .HasColumnName("TIPOVINCULO")
                   .IsRequired();

            builder.Property(x => x.TarefaId)
                   .HasColumnName("TAREFAID")
                   .IsRequired();

            // 🔗 Tarefa (obrigatório)
            builder.HasOne(x => x.Tarefa)
                   .WithMany(x => x.ListasTarefa)
                   .HasForeignKey(x => x.TarefaId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_LISTATAREFA_TAREFA");

            // 🔗 Responsável (opcional)
            builder.HasOne(x => x.Responsavel)
                   .WithMany()
                   .HasForeignKey(x => x.ResponsavelId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_LISTATAREFA_USUARIO");

            // 🔗 Envolvidos (N:N indireto)
            builder.HasMany(x => x.GrupoTarefaEnvolvido)
                   .WithOne(x => x.ListaTarefa)
                   .HasForeignKey(x => x.ListaTarefaId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_LISTATAREFA_ENVOLVIDO");

            // ⚠️ IMPORTANTE: não tem FK direta para Processo/Atendimento/Caso
        }
    }
}
