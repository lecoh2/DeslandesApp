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
    public class ProcessoHistoricoMap : IEntityTypeConfiguration<ProcessoHistorico>
    {
        public void Configure(EntityTypeBuilder<ProcessoHistorico> builder)
        {
            builder.ToTable("PROCESSOHISTORICO");
            builder.HasKey(p => p.Id);
          

            builder.Property(p => p.IdUsuario).HasColumnName("USUARIO_ID");

            builder.Property(p => p.DataAlteracao).HasColumnName("DATAALTERACAO").IsRequired(false);

            builder.Property(p => p.Observacoes)
                .HasColumnName("OBSERVACOES").HasColumnType("VARCHAR(255)").IsRequired(false);

            builder.Property(p => p.DadosAntes).HasColumnName("DADOSANTES").HasColumnType("VARCHAR(MAX)").IsRequired(false);

            builder.Property(p => p.DadosDepois).HasColumnName("DADOSDEPOIS").HasColumnType("VARCHAR(MAX)").IsRequired(false);

            // Relacionamento com Pessoa (opcional)
            builder.HasOne(p => p.Acao)
                .WithMany()
                .HasForeignKey(p => p.IdAcao)
                .HasConstraintName("FK_ProcessoHistorico_Acao")
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento com Usuario
            builder.HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.IdUsuario)
                .HasConstraintName("FK_UsuarioHistorico_USuario")
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Processo)
    .WithMany()
    .HasForeignKey(p => p.ProcessoId)
    .HasConstraintName("FK_PROCESSOHISTORICO_PROCESSOS_PROCESSOID")
    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

