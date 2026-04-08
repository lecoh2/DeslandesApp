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

    public class GrupoPessoasEtiquetasMap : IEntityTypeConfiguration<GrupoPessoasEtiquetas>
    {
        public void Configure(EntityTypeBuilder<GrupoPessoasEtiquetas> builder)
        {
            builder.HasKey(x => new { x.EtiquetaId, x.PessoaId });

            builder.HasOne(x => x.Etiqueta)
                .WithMany(p => p.GrupoPessoasEtiquetas)
                .HasForeignKey(x => x.EtiquetaId);

            builder.HasOne(x => x.Pessoa)
                .WithMany(p => p.GrupoPessoasEtiquetas)
                .HasForeignKey(x => x.PessoaId);


        }
    }
}
