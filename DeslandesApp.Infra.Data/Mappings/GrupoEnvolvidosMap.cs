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
    public class GrupoEnvolvidosMap : IEntityTypeConfiguration<GrupoEnvolvidos>
    {
        public void Configure(EntityTypeBuilder<GrupoEnvolvidos> builder)
        {
            builder.HasKey(x => new { x.IdPessoa, x.IdProcesso,x.IdQualificacao });

            builder.HasOne(x => x.Pessoa)
                .WithMany(p => p.GrupoEnvolvidos)
                .HasForeignKey(x => x.IdPessoa);

            builder.HasOne(x => x.Processo)
                .WithMany(p => p.GrupoEnvolvidos)
                .HasForeignKey(x => x.IdProcesso);

            builder.HasOne(x => x.QualificacaoEnvolvidos)
            .WithMany()
            .HasForeignKey(x => x.IdQualificacao)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
