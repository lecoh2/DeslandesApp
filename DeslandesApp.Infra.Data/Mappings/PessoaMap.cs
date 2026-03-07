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
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("PESSOA");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .IsRequired();

            builder.Property(p => p.DataCadastro)
                .HasColumnName("DATACADASTRO")
                .IsRequired();

            builder.Property(p => p.DataAtualizacao)
                .HasColumnName("DATAATUALIZACAO")
                .IsRequired(false);

            builder.Property(p => p.IdSexo)
                .HasColumnName("SEXO_ID")
                .IsRequired();

            builder.Property(p => p.IdUsuario)
                .HasColumnName("USUARIO_ID")
                .IsRequired();

            builder.OwnsOne(c => c.ValorEmail, e =>
            {
                e.Property(p => p.EnderecoEmail)
                 .HasColumnName("EMAIL")
                 .HasMaxLength(150)
                 .IsRequired();

                e.HasIndex(p => p.EnderecoEmail)
                 .IsUnique();
            });

            // RELACIONAMENTO SEXO
            builder.HasOne(s => s.Sexo)
                   .WithMany(p => p.Pessoa)
                   .HasForeignKey(s => s.IdSexo)
                   .IsRequired();

            // RELACIONAMENTO USUARIO
            builder.HasOne(p => p.Usuario)
                   .WithMany(u => u.Pessoa)
                   .HasForeignKey(p => p.IdUsuario)
                   .OnDelete(DeleteBehavior.Restrict);

            // HERANÇA
            builder.HasDiscriminator<string>("TIPO")
                   .HasValue<PessoaFisica>("PESSOAFISICA")
                   .HasValue<PessoaJuridica>("PESSOAJURIDICA");
        }
    }


}