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
    public class GrupoEtiquetasAtendimentoMap : IEntityTypeConfiguration<GrupoEtiquetasAtendimentos>
    {
        public void Configure(EntityTypeBuilder<GrupoEtiquetasAtendimentos> builder)
        {
            builder.HasKey(x => new { x.EtiquetaId, x.AtendimentoId });

            builder.HasOne(x => x.Etiqueta)
                .WithMany(p => p.GrupoEtiquetasAtendimentos)
                .HasForeignKey(x => x.EtiquetaId);

            builder.HasOne(x => x.Atendimento)
                .WithMany(p => p.GrupoEtiquetasAtendimentos)
                .HasForeignKey(x => x.AtendimentoId);

        }
    }
    }