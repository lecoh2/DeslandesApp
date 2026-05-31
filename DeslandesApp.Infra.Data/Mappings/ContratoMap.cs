using DeslandesApp.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeslandesApp.Infra.Data.Mappings
{
    public class ContratoMap : IEntityTypeConfiguration<Contrato>
    {
        public void Configure(EntityTypeBuilder<Contrato> builder)
        {
            builder.ToTable("CONTRATO");

            builder.HasKey(x => x.Id);

            // =========================
            // CAMPOS
            // =========================
            builder.Property(x => x.Numero)
                .HasColumnName("NUMERO")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Objeto)
                .HasColumnName("OBJETO")
                .HasMaxLength(500);

            builder.Property(x => x.ValorTotal)
                .HasColumnName("VALOR_TOTAL")
                .HasPrecision(18, 2);

            builder.Property(x => x.DataInicio)
                .HasColumnName("DATA_INICIO");

            builder.Property(x => x.DataFim)
                .HasColumnName("DATA_FIM");

            // =========================
            // CLIENTE (PESSOA)
            // =========================
            builder.HasOne(x => x.Pessoa)
                .WithMany()
                .HasForeignKey(x => x.PessoaId)
                .OnDelete(DeleteBehavior.Restrict);

            // =========================
            // CONTAS RECEBER
            // =========================
            builder.HasMany(x => x.ContasReceber)
                .WithOne(x => x.Contrato)
                .HasForeignKey(x => x.ContratoId)
                .OnDelete(DeleteBehavior.Cascade);

            // =========================
            // SOFT DELETE
            // =========================
            builder.HasQueryFilter(x => !x.Excluido);
        }
    }
}