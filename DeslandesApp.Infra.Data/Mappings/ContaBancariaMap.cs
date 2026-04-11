using DeslandesApp.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ContaBancariaMap : IEntityTypeConfiguration<ContaBancaria>
{
    public void Configure(EntityTypeBuilder<ContaBancaria> builder)
    {
        builder.ToTable("CONTABANCARIA");

        // ✅ PK (vem do BaseEntity)
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
               .ValueGeneratedOnAdd();

        // ================= CAMPOS =================

        builder.Property(c => c.NomeBanco)
               .HasMaxLength(100)
               .IsRequired(false);

        builder.Property(c => c.Agencia)
               .HasMaxLength(20)
               .IsRequired(false);

        builder.Property(c => c.NumeroConta)
               .HasMaxLength(50)
               .IsRequired(false);

        builder.Property(c => c.Pix)
               .HasMaxLength(100)
               .IsRequired(false);

        // ✅ ENUM CORRETO (SEM RELACIONAMENTO)
        builder.Property(c => c.TipoConta)
               .HasColumnName("TIPOCONTA")
               .IsRequired(false);

        // ================= RELACIONAMENTO =================

        builder.HasOne(c => c.Pessoa)
               .WithMany(p => p.ContasBancarias)
               .HasForeignKey(c => c.PessoaId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}