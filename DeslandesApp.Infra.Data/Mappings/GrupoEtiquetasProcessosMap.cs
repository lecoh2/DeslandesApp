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
    public class GrupoEtiquetasProcessosMap : IEntityTypeConfiguration<GrupoEtiquetasProcessos>
    {
        public void Configure(EntityTypeBuilder<GrupoEtiquetasProcessos> builder)
        {
            builder.HasKey(x => new { x.EtiquetaId, x.ProcessoId });

            builder.HasOne(x => x.Etiqueta)
                .WithMany(p => p.GrupoEtiquetasProcessos)
                .HasForeignKey(x => x.EtiquetaId);

            builder.HasOne(x => x.Processo)
                .WithMany(p => p.GrupoEtiquetasProcessos)
                .HasForeignKey(x => x.ProcessoId);

        }
    }
    }