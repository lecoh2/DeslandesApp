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
    public class GrupoEnvolvidosProcessosMap : IEntityTypeConfiguration<GrupoEnvolvidosProcesso>
    {
        public void Configure(EntityTypeBuilder<GrupoEnvolvidosProcesso> builder)
        {
            builder.HasKey(x => new { x.PessoaId, x.ProcessoId, x.QualificacaoId });

            builder.HasOne(x => x.Pessoa)
                .WithMany(p => p.GrupoEnvolvidosProcesso)
                .HasForeignKey(x => x.PessoaId);

            builder.HasOne(x => x.Processo)
                .WithMany(p => p.GrupoEnvolvidosProcesso)
                .HasForeignKey(x => x.ProcessoId);
            builder.HasOne(x => x.Qualificacao)
       .WithMany()
       .HasForeignKey(x => x.QualificacaoId)
       .OnDelete(DeleteBehavior.Restrict);

        }
    }
}