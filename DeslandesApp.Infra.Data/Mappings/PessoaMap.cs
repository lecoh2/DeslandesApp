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
            builder.Property(p => p.Nome).HasColumnName("NOME").IsRequired();
            builder.Property(p => p.DataCadastro).HasColumnName("DATACADASTRO").IsRequired();
            builder.Property(p => p.DataAtualizacao).HasColumnName("DATATATUALIZACAO");
            builder.Property(p => p.Email).HasColumnName("EMAIL").IsRequired();
            builder.HasIndex(p => p.Email).IsUnique();
            builder.Property(p => p.IdSexo).HasColumnName("SEXO_ID").IsRequired(false);
            builder.Ignore(p => p.UsuarioCadastro);
            builder.Property(p => p.IdUsuarioCadastro).HasColumnName("USUARIO_ID").IsRequired(false);
            #region Relacionamentos



            // Relacionamento com Sexo
            builder.HasOne(p => p.Sexo)
                   .WithMany(s => s.Pessoa)
                   .HasForeignKey(p => p.IdSexo).IsRequired(false);

            // Relacionamento com Usuario (1:1)
            builder.HasOne(p => p.Usuario)
                   .WithOne(u => u.Pessoa)
                   .HasForeignKey<Usuario>(u => u.IdPessoa)
                   .OnDelete(DeleteBehavior.Restrict);



            // Herança (TPH)
            builder.HasDiscriminator<string>("TIPO")
                   .HasValue<PessoaFisica>("PESSOAFISICA")
                   .HasValue<PessoaJuridica>("PESSOAJURIDICA");
            #endregion
        }
    }


}