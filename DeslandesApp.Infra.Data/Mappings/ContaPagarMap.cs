using DeslandesApp.Domain.Models.Entities;
using DocumentFormat.OpenXml.Vml.Office;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeslandesApp.Infra.Data.Mappings
{
    public class ContaPagarMap : IEntityTypeConfiguration<ContaPagar>
    {
        public void Configure(EntityTypeBuilder<ContaPagar> builder)
        {
            builder.ToTable("CONTA_PAGAR");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(x => x.Valor)
                .HasPrecision(18, 2);

            builder.Property(x => x.ValorPago)
                .HasPrecision(18, 2);

            builder.Property(x => x.DataVencimento)
                .IsRequired();

            // =========================
            // PESSOA (FORNECEDOR)
            // =========================
            builder.HasOne(x => x.Pessoa)
                .WithMany()
                .HasForeignKey(x => x.PessoaId)
                .OnDelete(DeleteBehavior.Restrict);

            // =========================
            // CONTRATO (OPCIONAL)
            // =========================
            builder.HasOne(x => x.Contrato)
                .WithMany()
                .HasForeignKey(x => x.ContratoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(x => !x.Excluido);
            builder.HasOne(x => x.CategoriaFinanceira)
    .WithMany()
    .HasForeignKey(x => x.CategoriaFinanceiraId)
    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}