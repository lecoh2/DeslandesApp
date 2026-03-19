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
    public class GrupoAtendimentoClienteMap : IEntityTypeConfiguration<GrupoAtendimentoCliente>
    {
        public void Configure(EntityTypeBuilder<GrupoAtendimentoCliente> builder)
        {
            builder.ToTable("ATENDIMENTCLIENTE");

            builder.HasKey(x => new { x.AtendimentoId, x.PessoaId });

            builder.Property(x => x.AtendimentoId).HasColumnName("ATENDIMENTOID");
            builder.Property(x => x.PessoaId).HasColumnName("PESSOAID");

            builder.HasOne(x => x.Atendimento)
                   .WithMany(x => x.GrupoClientes)
                   .HasForeignKey(x => x.AtendimentoId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Pessoa)
                   .WithMany()
                   .HasForeignKey(x => x.PessoaId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}