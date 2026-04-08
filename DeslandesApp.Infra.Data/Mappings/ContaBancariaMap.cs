using DeslandesApp.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Infra.Data.Mappings
{
    public class ContaBancariaMap : IEntityTypeConfiguration<ContaBancaria>
    {
        public void Configure(EntityTypeBuilder<ContaBancaria> builder)
        {
            // Nome da tabela
            builder.ToTable("CONTABANCARIA");

            // Chave primária
            builder.HasKey(c => c.NumeroConta);

            // Propriedades
            builder.Property(c => c.NomeBanco)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(c => c.Agencia)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(c => c.Pix)
                   .HasMaxLength(100);

            // Enum TipoConta como coluna
            builder.Property(c => c.TipoConta)
                   .HasColumnName("TipoConta")
                   .HasConversion<int>(); // salva enum como int

            // Relacionamentos

            // Pessoa (opcional)
            builder.HasOne(c => c.Pessoa)
                   .WithMany(p => p.ContasBancarias)
                   .HasForeignKey("PessoaId")
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}