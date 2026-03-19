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
    public class EventoResponsavelMap : IEntityTypeConfiguration<GrupoEventoResponsavel>
    {
        public void Configure(EntityTypeBuilder<GrupoEventoResponsavel> builder)
        {
            builder.ToTable("EVENTORESPONSAVEL");

            builder.HasKey(x => new { x.EventoId, x.PessoaId });

            builder.Property(x => x.EventoId).HasColumnName("EVENTOID");
            builder.Property(x => x.PessoaId).HasColumnName("PESSOAID");

            builder.HasOne(x => x.Evento)
                   .WithMany(x => x.GrupoEventoResponsavel)
                   .HasForeignKey(x => x.EventoId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Pessoa)
                   .WithMany()
                   .HasForeignKey(x => x.PessoaId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
