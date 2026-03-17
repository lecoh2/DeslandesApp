using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Infra.Data.Mappings
{
    public class ProcessoMap : IEntityTypeConfiguration<Processo>
    {
        public void Configure(EntityTypeBuilder<Processo> builder)
        {
            builder.HasKey(x => x.Id);

            // 🔗 RELACIONAMENTO COM FORO
            builder.HasOne(x => x.Foro)
                .WithMany()
                .HasForeignKey(x => x.IdForo)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔗 RELACIONAMENTO COM ACAO
            builder.HasOne(x => x.Acao)
                .WithMany()
                .HasForeignKey(x => x.IdAcao)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔥 RELACIONAMENTO N:N (via tabela de junção)
            builder.HasMany(x => x.GrupoPessoaClientes)
                .WithOne(x => x.Processo)
                .HasForeignKey(x => x.IdProcesso);

            builder.HasMany(x => x.GrupoEnvolvidos)
               .WithOne(x => x.Processo)
               .HasForeignKey(x => x.IdProcesso);


            // 💡 DATEONLY (IMPORTANTE)
            builder.Property(x => x.Distribuido)
                .HasConversion<NullableDateOnlyConverter, NullableDateOnlyComparer>();
        }
    }
}
