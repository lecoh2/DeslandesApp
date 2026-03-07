using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Infra.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIOS");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Login).HasColumnName("LOGIN").IsRequired();
            builder.Property(u => u.Senha).HasColumnName("SENHA").IsRequired();
            builder.Property(u => u.DataCadastro).HasColumnName("DATACADASTRO").IsRequired();
            builder.Property(u => u.DataAtualizacao).HasColumnName("DATAATUALIZACAO").IsRequired(false);
            builder.Property(u => u.Status).HasColumnName("STATUS").IsRequired(false);

            builder.Property(u => u.ValorEmail)
            .HasConversion(
                v => v == null ? null : v.EnderecoEmail,
                v => v == null ? null : new ValorEmail(v))
            .HasColumnName("EMAIL")
            .HasMaxLength(150)
            .IsRequired(false);



            builder.HasMany(u => u.Pessoa)
                .WithOne(p => p.Usuario)
                .HasForeignKey(p => p.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
