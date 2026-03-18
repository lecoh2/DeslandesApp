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

            // 🔗 RELACIONAMENTO COM FORO (1:N)
            builder.HasOne(x => x.Foro)
                .WithMany() // ou .WithMany(f => f.Processos) se você adicionar a coleção no Foro
                .HasForeignKey(x => x.ForoId)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔗 RELACIONAMENTO COM ACAO (1:N)
            builder.HasOne(x => x.Acao)
                .WithMany()
                .HasForeignKey(x => x.AcaoId)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔥 RELAÇÃO N:N (tabela de junção)
            builder.HasMany(x => x.GrupoPessoaClientes)
                .WithOne(x => x.Processo)
                .HasForeignKey(x => x.ProcessoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.GrupoEnvolvidos)
                .WithOne(x => x.Processo)
                .HasForeignKey(x => x.ProcessoId)
                .OnDelete(DeleteBehavior.Cascade);

            // 💡 DATEONLY
            builder.Property(x => x.Distribuido)
                .HasConversion<NullableDateOnlyConverter, NullableDateOnlyComparer>();
        }
    }
}
