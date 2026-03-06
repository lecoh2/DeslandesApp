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
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIOS");

            builder.HasKey(u => u.Id);
   
            builder.Property(u => u.Login).HasColumnName("LOGIN").IsRequired(false);
            builder.Property(u => u.Senha).HasColumnName("SENHA").IsRequired(false);
            builder.Property(u => u.DataCadastro).HasColumnName("DATACADASTRO").IsRequired(false);
            builder.Property(u => u.DataAtualizacao).HasColumnName("DATAATUALIZACAO").IsRequired(false);
            builder.Property(u => u.Status).HasColumnName("STATUS").IsRequired(false);
            builder.Property(u => u.IdPessoa).HasColumnName("PESSOA_ID").IsRequired();
            builder.OwnsOne(c => c.ValorEmail, e =>
            {
                e.Property(p => p.EnderecoEmail)
                .HasColumnName("ValorEmail")
                .HasMaxLength(150)
                .IsRequired();
                e.HasIndex(p => p.EnderecoEmail)
                .IsUnique();
            });
            #region Relacionamento com Pessoa
            builder.HasOne(u => u.Pessoa)
                   .WithOne(p => p.Usuario)
                   .HasForeignKey<Usuario>(u => u.IdPessoa)
                   .OnDelete(DeleteBehavior.Restrict); // Garantir que o relacionamento é restrito
            #endregion
        }
    }
}
