using DeslandesApp.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeslandesApp.Infra.Data.Mappings
{
    public class ContaReceberMap : IEntityTypeConfiguration<ContaReceber>
    {
        public void Configure(EntityTypeBuilder<ContaReceber> builder)
        {
            builder.ToTable("CONTA_RECEBER");

            builder.HasKey(x => x.Id);

            // =========================
            // CAMPOS
            // =========================
            builder.Property(x => x.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(300);

            builder.Property(x => x.Valor)
                .HasColumnName("VALOR")
                .HasPrecision(18, 2);

            builder.Property(x => x.ValorPago)
                .HasColumnName("VALOR_PAGO")
                .HasPrecision(18, 2);

            builder.Property(x => x.DataVencimento)
                .HasColumnName("DATA_VENCIMENTO");

            builder.Property(x => x.Status)
                .HasColumnName("STATUS");

            // =========================
            // CLIENTE (PESSOA)
            // =========================
            builder.HasOne(x => x.Pessoa)
                .WithMany()
                .HasForeignKey(x => x.PessoaId)
                .OnDelete(DeleteBehavior.Restrict);

            // =========================
            // CONTRATO
            // =========================
            builder.HasOne(x => x.Contrato)
                .WithMany(x => x.ContasReceber)
                .HasForeignKey(x => x.ContratoId)
                .OnDelete(DeleteBehavior.Cascade);

            // =========================
            // SOFT DELETE
            // =========================
            builder.HasQueryFilter(x => !x.Excluido);
            builder.HasOne(x => x.CategoriaFinanceira)
    .WithMany()
    .HasForeignKey(x => x.CategoriaFinanceiraId)
    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}