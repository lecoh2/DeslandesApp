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

            builder.Property(x => x.Numero)
                .HasColumnName("NUMERO")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Objeto)
                .HasColumnName("OBJETO")
                .HasMaxLength(500);


            builder.Property(x => x.DataInicio)
                .HasColumnName("DATA_INICIO");

            builder.Property(x => x.DataFim)
                .HasColumnName("DATA_FIM");
            builder.Property(x => x.Observacao)
                .HasColumnName("OBSERVACAO").HasMaxLength(255);
             

            builder.HasMany(x => x.ContratoProcessos)
       .WithOne(x => x.Contrato)
       .HasForeignKey(x => x.ContratoId);

            builder.HasOne(x => x.Pessoa)
                    .WithMany()
                    .HasForeignKey(x => x.PessoaId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.ContasReceber)
                .WithOne(x => x.Contrato)
                .HasForeignKey(x => x.ContratoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(x => !x.Excluido);
        }
    }
}
