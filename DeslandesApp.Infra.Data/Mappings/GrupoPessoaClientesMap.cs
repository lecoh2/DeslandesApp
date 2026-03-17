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
            builder.HasKey(x => new { x.IdPessoa, x.IdProcesso });

            builder.HasOne(x => x.Pessoa)
                .WithMany(p => p.GrupoPessoaClientes)
                .HasForeignKey(x => x.IdPessoa);

            builder.HasOne(x => x.Processo)
                .WithMany(p => p.GrupoPessoaClientes)
                .HasForeignKey(x => x.IdProcesso);
        }
    }
}
