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
    public class GrupoPessoaClientesMap : IEntityTypeConfiguration<GrupoPessoaClientes>
    {
        public void Configure(EntityTypeBuilder<GrupoPessoaClientes> builder)
        {
            builder.HasKey(x => new { x.PessoaId, x.ProcessoId, x.QualificacaoId });

            builder.HasOne(x => x.Pessoa)
                .WithMany(p => p.GrupoPessoaClientes)
                .HasForeignKey(x => x.PessoaId);

            builder.HasOne(x => x.Processo)
                .WithMany(p => p.GrupoPessoaClientes)
                .HasForeignKey(x => x.ProcessoId);

            builder.HasOne(x => x.QualificacaoCliente)
            .WithMany()
            .HasForeignKey(x => x.QualificacaoId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
