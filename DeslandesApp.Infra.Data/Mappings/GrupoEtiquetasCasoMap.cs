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
    public class GrupoEtiquetasCasoMap :IEntityTypeConfiguration<GrupoEtiquetaCasos>
    {
        public void Configure(EntityTypeBuilder<GrupoEtiquetaCasos> builder)
    {
        builder.HasKey(x => new { x.EtiquetaId, x.CasoId });

        builder.HasOne(x => x.Etiqueta)
            .WithMany(p => p.GrupoEtiquetasCasos)
            .HasForeignKey(x => x.EtiquetaId);

        builder.HasOne(x => x.Caso)
            .WithMany(p => p.GrupoEtiquetaCasos)
            .HasForeignKey(x => x.CasoId);

    }
}
    }