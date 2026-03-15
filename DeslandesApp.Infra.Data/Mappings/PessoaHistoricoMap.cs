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
    internal class PessoaHistoricoMap : IEntityTypeConfiguration<PessoaHistorico>
    {
        public void Configure(EntityTypeBuilder<PessoaHistorico> builder)
        {
            builder.ToTable("PESSOA_HISTORICO");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.IdPessoa).HasColumnName("PESSOA_ID").IsRequired();

            builder.Property(p => p.IdUsuario).HasColumnName("USUARIO_ID");

            builder.Property(p => p.DataAlteracao).HasColumnName("DATAALTERACAO").IsRequired();

            builder.Property(p => p.Observacoes)
                .HasColumnName("OBSERVACOES").HasColumnType("VARCHAR(255)").IsRequired();

            builder.Property(p => p.DadosAntes).HasColumnName("DADOSANTES").HasColumnType("VARCHAR(MAX)").IsRequired();

            builder.Property(p => p.DadosDepois).HasColumnName("DADOSDEPOIS").HasColumnType("VARCHAR(MAX)").IsRequired();

            // Relacionamento com Pessoa (opcional)
            builder.HasOne(p => p.Pessoa)
                .WithMany()
                .HasForeignKey(p => p.IdPessoa)
                .HasConstraintName("FK_PessoaHistorico_Pessoa")
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento com Usuario
            builder.HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.IdUsuario)
                .HasConstraintName("FK_PessoaHistorico_Usuario")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

