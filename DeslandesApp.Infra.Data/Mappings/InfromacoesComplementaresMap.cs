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
    public  class InfromacoesComplementaresMap : IEntityTypeConfiguration<InformacoesComplementares>
    {
        public void Configure(EntityTypeBuilder<InformacoesComplementares> builder)
        {

            builder.ToTable("INFORMACOESCOMPLEMENTARES");

            builder.HasKey(e => e.Id);

            
            builder.Property(e => e.DataNascimento).HasColumnName("DATANASCIMENTO").HasMaxLength(10).IsRequired(false);
            builder.Property(e => e.NomeEmpresa).HasColumnName("NOMEEMPRESA").IsRequired(false); 
            builder.Property(e => e.Profissao)
    .HasColumnName("PROFISSAO")
    .HasMaxLength(250)
    .IsRequired(false); // <- ESSENCIAL
            builder.Property(e => e.AtividadeEconomica).HasColumnName("ATIVIDADEECONOMICA").IsRequired(false);
            builder.Property(e => e.EstadoCivil).HasColumnName("ESTADOCIVIL").IsRequired(false);
            builder.Property(e => e.Codigo).HasColumnName("CODIGO").HasMaxLength(100).IsRequired(false);
            builder.Property(e => e.NomePai).HasColumnName("NOMEPAI").HasMaxLength(250).IsRequired(false);
            builder.Property(e => e.NomeMae).HasColumnName("NOMEMAE").HasMaxLength(250).IsRequired(false);
            builder.Property(e => e.Naturalidade).HasColumnName("NATURALIDADE").HasMaxLength(50).IsRequired(false);
            builder.Property(e => e.Nacionalidade).HasColumnName("NASCIONALIDADE").HasMaxLength(50).IsRequired(false);
            builder.Property(e => e.Comentario).HasColumnName("COMENTARIO").HasMaxLength(250).IsRequired(false);
                        builder.Property(e => e.IdPessoa).HasColumnName("PESSOA_ID").IsRequired();

            #region Relacionamentos
            builder.HasOne(e => e.Pessoa)
                .WithOne(p => p.InformacoesComplementares)
                .HasForeignKey<InformacoesComplementares>(e => e.IdPessoa)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }

    }
}

