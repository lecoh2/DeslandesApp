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
    public class AtendimentoHistoricoMap : IEntityTypeConfiguration<AtendimentoHistorico>
    {
        public void Configure(EntityTypeBuilder<AtendimentoHistorico> builder)
        {
            builder.ToTable("ATENDIMENTOHISTORICO");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.AtendimentoId)
                .HasColumnName("ATENDIMENTO_ID")
                .IsRequired();

            builder.Property(a => a.IdUsuario)
                .HasColumnName("USUARIO_ID");

            builder.Property(a => a.DataAlteracao)
                .HasColumnName("DATAALTERACAO")
                .IsRequired(false);

            builder.Property(a => a.Observacao)
                .HasColumnName("OBSERVACAO")
                .HasColumnType("VARCHAR(255)")
                .IsRequired(false);

            builder.Property(a => a.DadosAntes)
                .HasColumnName("DADOSANTES")
                .HasColumnType("VARCHAR(MAX)")
                .IsRequired(false);

            builder.Property(a => a.DadosDepois)
                .HasColumnName("DADOSDEPOIS")
                .HasColumnType("VARCHAR(MAX)")
                .IsRequired(false);

            // 🔗 Relacionamento com Atendimento
            builder.HasOne(a => a.Atendimento)
                .WithMany()
                .HasForeignKey(a => a.AtendimentoId)
                .HasConstraintName("FK_AtendimentoHistorico_Atendimento")
                .OnDelete(DeleteBehavior.Restrict);

            // 🔗 Relacionamento com Usuario
            builder.HasOne(a => a.Usuario)
                .WithMany()
                .HasForeignKey(a => a.IdUsuario)
                .HasConstraintName("FK_AtendimentoHistorico_Usuario")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
