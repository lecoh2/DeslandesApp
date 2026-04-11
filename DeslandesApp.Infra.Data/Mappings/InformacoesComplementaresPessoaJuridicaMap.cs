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
    public class InformacoesComplementaresPessoaJuridicaMap : IEntityTypeConfiguration<InformacoesComplementaresPessoaJuridica>
    {
        public void Configure(EntityTypeBuilder<InformacoesComplementaresPessoaJuridica> builder)
        {
            builder.Property(e => e.Contato)
                .HasColumnName("CONTATO").IsRequired(false);

            builder.Property(e => e.Cargo)
                .HasColumnName("CARGO")
                .HasMaxLength(250).IsRequired(false);
      

            builder.Property(e => e.Comentario)
                .HasColumnName("COMENTARIO")
               .IsRequired(false);
        }
    }
}
