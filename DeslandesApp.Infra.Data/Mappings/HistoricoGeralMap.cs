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

        // 🕒 DATA
        builder.Property(x => x.DataAlteracao)
            .IsRequired();

        // 📝 OBS
        builder.Property(x => x.Observacao)
            .HasMaxLength(500);

        // 📦 JSON
        builder.Property(x => x.DadosAntes)
            .IsRequired()
            .HasColumnType("text");

        builder.Property(x => x.DadosDepois)
            .IsRequired()
            .HasColumnType("text");

        // 🌐 IP
        builder.Property(x => x.Ip)
            .HasMaxLength(50); // IPv4/IPv6

        // 🧠 USER AGENT
        builder.Property(x => x.UserAgent)
            .HasMaxLength(500);

        // 🔎 INDEXES (melhorando performance)
        builder.HasIndex(x => x.Entidade);
        builder.HasIndex(x => x.EntidadeId);
        builder.HasIndex(x => x.DataAlteracao);

        // 🔥 OPCIONAL (muito bom)
        builder.HasIndex(x => new { x.Entidade, x.EntidadeId });
    }
}