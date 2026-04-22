using DeslandesApp.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class HistoricoGeralMap : IEntityTypeConfiguration<HistoricoGeral>
{
    public void Configure(EntityTypeBuilder<HistoricoGeral> builder)
    {
        builder.ToTable("HistoricoGeral");

        builder.HasKey(x => x.Id);

        // 📌 ENUM convertido para int
        builder.Property(x => x.Entidade)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(x => x.EntidadeId)
            .IsRequired();

        builder.Property(x => x.UsuarioId);

        builder.HasOne(x => x.Usuario)
            .WithMany()
            .HasForeignKey(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.DataAlteracao)
            .IsRequired();

        builder.Property(x => x.Observacao)
            .HasMaxLength(500);

        builder.Property(x => x.DadosAntes)
            .IsRequired()
            .HasColumnType("text");

        builder.Property(x => x.DadosDepois)
            .IsRequired()
            .HasColumnType("text");

        builder.HasIndex(x => x.Entidade);
        builder.HasIndex(x => x.EntidadeId);
        builder.HasIndex(x => x.DataAlteracao);
    }
}