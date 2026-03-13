using DeslandesApp.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeslandesApp.Infra.Data.Mappings
{
    public class InformacoesComplementaresMap : IEntityTypeConfiguration<InformacoesComplementares>
    {
        public void Configure(EntityTypeBuilder<InformacoesComplementares> builder)
        {
            builder.ToTable("INFORMACOESCOMPLEMENTARES");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Codigo).HasColumnName("CODIGO").HasMaxLength(50).IsRequired(false);
            builder.Property(e => e.Comentario)
                .HasColumnName("COMENTARIO")
                .HasMaxLength(250)
                .IsRequired(false);
            builder.Property(p => p.IdPessoa)
               .HasColumnName("PESSOA_ID")
               .IsRequired();

            // Discriminador para PF e PJ
            builder
                .HasDiscriminator<string>("TIPOPESSOA")
                .HasValue<InformacoesComplementaresPessoaFisica>("PF")
                .HasValue<InformacoesComplementaresPessoaJuridica>("PJ");

            #region Relacionamentos
            builder.HasOne(e => e.Pessoa)
                .WithOne(p => p.InformacoesComplementares)
                .HasForeignKey<InformacoesComplementares>(e => e.IdPessoa)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}