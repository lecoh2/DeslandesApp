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
    public class CasoMap : IEntityTypeConfiguration<Caso>
    {
        public void Configure(EntityTypeBuilder<Caso> builder)
        {
            builder.ToTable("CASO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Pasta)
                   .HasMaxLength(250)
                   .IsUnicode(false)
                   .HasColumnName("PASTA");

            builder.Property(x => x.Titulo)
                   .HasMaxLength(250)
                   .IsUnicode(false)
                   .HasColumnName("TITULO");

            builder.Property(x => x.Descricao)
                   .HasMaxLength(2000)
                   .IsUnicode(false)
                   .HasColumnName("DESCRICAO");

            builder.Property(x => x.Observacao)
                   .HasMaxLength(2000)
                   .IsUnicode(false)
                   .HasColumnName("OBSERVACAO");
            builder.Property(x => x.DataCadastro).HasColumnName("DATACADASTRO").IsRequired(false);

            builder.Property(x => x.ResponsavelId)
                   .HasColumnName("RESPONSAVELID");

            builder.Property(x => x.Acesso)
                   .HasColumnName("ACESSO");

            builder.HasOne(x => x.Responsavel)
                   .WithMany()
                   .HasForeignKey(x => x.ResponsavelId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_CASO_USUARIO");

            builder.HasMany(x => x.GrupoCasoCliente)
                   .WithOne(x => x.Caso)
                   .HasForeignKey(x => x.CasoId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_CASO_CASOCLIENTE");

            builder.HasMany(x => x.GrupoCasoEnvolvido)
                   .WithOne(x => x.Caso)
                   .HasForeignKey(x => x.CasoId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_CASO_CASOENVOLVIDO");
        }
    }
}