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
    public class ContratoProcessoMap : IEntityTypeConfiguration<ContratoProcesso>
    {
        public void Configure(EntityTypeBuilder<ContratoProcesso> builder)
        {
            builder.ToTable("CONTRATO_PROCESSO");

            builder.HasKey(x => new { x.ContratoId, x.ProcessoId });

            builder.HasOne(x => x.Contrato)
                .WithMany(x => x.ContratoProcessos)
                .HasForeignKey(x => x.ContratoId);

            builder.HasOne(x => x.Processo)
                .WithMany(x => x.ContratoProcessos)
                .HasForeignKey(x => x.ProcessoId);
        }
    }
}
