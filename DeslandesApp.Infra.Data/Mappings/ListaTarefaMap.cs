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

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Prioridade)
                   .HasColumnName("PRIORIDADE");

            builder.Property(x => x.ResponsavelId)
                   .HasColumnName("RESPONSAVELID");

            builder.Property(x => x.ProcessoId)
                   .HasColumnName("PROCESSOID");

            builder.HasOne(x => x.Responsavel)
                   .WithMany()
                   .HasForeignKey(x => x.ResponsavelId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_LISTATAREFA_PESSOA");

            builder.HasOne(x => x.Processo)
                   .WithMany()
                   .HasForeignKey(x => x.ProcessoId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_LISTATAREFA_PROCESSO");

            builder.HasMany(x => x.GrupoTarefaEnvolvido)
                   .WithOne(x => x.ListaTarefa)
                   .HasForeignKey(x => x.ListaTarefaId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_LISTATAREFA_TAREFAENVOLVIDO");
        }
    }
}
