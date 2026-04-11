using DeslandesApp.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class InformacoesComplementaresPessoaFisicaMap
    : IEntityTypeConfiguration<InformacoesComplementaresPessoaFisica>
{
    public void Configure(EntityTypeBuilder<InformacoesComplementaresPessoaFisica> builder)
    {
        builder.Property(e => e.DataNascimento)
            .HasColumnName("DATANASCIMENTO").IsRequired(false);

        builder.Property(e => e.Profissao)
            .HasColumnName("PROFISSAO")
            .HasMaxLength(250).IsRequired(false);
        builder.Property(e => e.AtividadeEconomica).HasColumnName("ATIVIDADEECONOMICA").HasMaxLength(255).IsRequired(false);

        builder.Property(e => e.EstadoCivil)
            .HasColumnName("ESTADOCIVIL")
            .HasMaxLength(50).IsRequired(false);

        builder.Property(e => e.NomePai)
            .HasColumnName("NOMEPAI")
            .HasMaxLength(250).IsRequired(false);

        builder.Property(e => e.NomeMae)
            .HasColumnName("NOMEMAE")
            .HasMaxLength(250).IsRequired(false);

        builder.Property(e => e.Naturalidade)
            .HasColumnName("NATURALIDADE")
            .HasMaxLength(100).IsRequired(false);

        builder.Property(e => e.Nacionalidade)
            .HasColumnName("NACIONALIDADE")
            .HasMaxLength(100).IsRequired(false);
        builder.Property(e => e.Tratamento)
    .HasColumnName("TRATAMENTO")
    .HasConversion<int>() // <-- ESSENCIAL
    .IsRequired(false);
    }
}