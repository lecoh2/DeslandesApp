using DeslandesApp.Domain.Models.Entities;
using DocumentFormat.OpenXml.Vml.Office;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeslandesApp.Infra.Data.Mappings
{
    public class BaixaFinanceiraMap : IEntityTypeConfiguration<BaixaFinanceira>
    {
        public void Configure(EntityTypeBuilder<BaixaFinanceira> builder)
        {
            builder.ToTable("BAIXA_FINANCEIRA");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ValorPago)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.DataBaixa)
                .IsRequired();

            builder.Property(x => x.FormaRecebimento)
            .IsRequired();
            builder.HasOne(x => x.ContaReceber)
                .WithMany()
                .HasForeignKey(x => x.ContaReceberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ContaPagar)
                .WithMany()
                .HasForeignKey(x => x.ContaPagarId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(x => !x.Excluido);
        }
    }
}