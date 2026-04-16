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
            builder.ToTable("GRUPOETIQUETASPROCESSOS"); // 🔥 importante

            builder.HasKey(x => new { x.EtiquetaId, x.ProcessoId });

            builder.HasOne(x => x.Etiqueta)
                .WithMany(p => p.GrupoEtiquetasProcessos)
                .HasForeignKey(x => x.EtiquetaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Processo)
                .WithMany(p => p.GrupoEtiquetasProcessos)
                .HasForeignKey(x => x.ProcessoId)
                .OnDelete(DeleteBehavior.Cascade);

            // 💣 ESSA LINHA RESOLVE SEU PROBLEMA
            builder.Ignore("PessoaId");
        }
    }
}
  