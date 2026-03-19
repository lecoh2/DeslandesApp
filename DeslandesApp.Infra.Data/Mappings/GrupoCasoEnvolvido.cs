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
    internal class GrupoCasoEnvolvidoMap : IEntityTypeConfiguration<GrupoCasoEnvolvido>
    {
        public void Configure(EntityTypeBuilder<GrupoCasoEnvolvido> builder)
        {
            builder.ToTable("GRUPOCASOENVOLVIDO");

            builder.HasKey(x => new { x.CasoId, x.PessoaId });

            builder.Property(x => x.CasoId).HasColumnName("CASOID");
            builder.Property(x => x.PessoaId).HasColumnName("PESSOAID");
            builder.Property(x => x.QualificacaoId).HasColumnName("QUALIFICACAOID");

            builder.HasOne(x => x.Caso)
                   .WithMany(x => x.GrupoCasoEnvolvido)
                   .HasForeignKey(x => x.CasoId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Pessoa)
                   .WithMany()
                   .HasForeignKey(x => x.PessoaId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Qualificacao)
                   .WithMany()
                   .HasForeignKey(x => x.QualificacaoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
