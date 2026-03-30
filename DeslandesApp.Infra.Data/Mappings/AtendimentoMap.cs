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
    public class AtendimentoMap : IEntityTypeConfiguration<Atendimento>
    {
        public void Configure(EntityTypeBuilder<Atendimento> builder)
        {
            builder.ToTable("ATENDIMENTO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Assunto)
                   .HasMaxLength(500)
                   .IsUnicode(false)
                   .HasColumnName("ASSUNTO");

            builder.Property(x => x.Registro)
                   .HasMaxLength(2000)
                   .IsUnicode(false)
                   .HasColumnName("REGISTRO");

            builder.Property(x => x.ProcessoId)
                   .HasColumnName("PROCESSOID");

            builder.HasOne(x => x.Processo)
                   .WithMany()
                   .HasForeignKey(x => x.ProcessoId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_ATENDIMENTO_PROCESSO");

            builder.HasMany(x => x.GrupoClientes)
                   .WithOne(x => x.Atendimento)
                   .HasForeignKey(x => x.AtendimentoId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_ATENDIMENTO_ATENDIMENTCLIENTE");

            // ✅ NOVO RELACIONAMENTO N:N
            builder.HasMany(x => x.GrupoEtiquetasAtendimentos)
                   .WithOne(x => x.Atendimento)
                   .HasForeignKey(x => x.AtendimentoId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_ATENDIMENTO_ETIQUETA");
        }
    }
}
