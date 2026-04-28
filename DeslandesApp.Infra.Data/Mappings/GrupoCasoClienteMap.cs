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
    public class GrupoCasoClienteMap : IEntityTypeConfiguration<GrupoCasoCliente>
    {
        public void Configure(EntityTypeBuilder<GrupoCasoCliente> builder)
        {
            builder.ToTable("GRUPOCASOCLIENTE");

            builder.HasKey(x => new { x.CasoId, x.PessoaId });

            builder.Property(x => x.CasoId).HasColumnName("CASOID");
            builder.Property(x => x.PessoaId).HasColumnName("PESSOAID");

            builder.HasOne(x => x.Caso)
                   .WithMany(x => x.GrupoCasoClientes)
                   .HasForeignKey(x => x.CasoId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Pessoa)
          .WithMany(x => x.GrupoCasoClientes) // ✅ agora ficou claro
          .HasForeignKey(x => x.PessoaId)
          .OnDelete(DeleteBehavior.Restrict);
        }
    }
}