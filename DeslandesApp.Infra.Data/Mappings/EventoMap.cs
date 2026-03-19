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
    public class EventoMap : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("EVENTO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
                   .HasMaxLength(250)
                   .IsUnicode(false)
                   .HasColumnName("TITULO");

            builder.Property(x => x.DataInicial).HasColumnName("DATAINICIAL");
            builder.Property(x => x.HoraInicial).HasColumnName("HORAINICIAL");

            builder.Property(x => x.DataFinal).HasColumnName("DATAFINAL");
            builder.Property(x => x.HoraFinal).HasColumnName("HORAFINAL");

            builder.Property(x => x.DiaInteiro).HasColumnName("DIAINTEIRO");

            builder.Property(x => x.Endereco)
                   .HasMaxLength(250)
                   .IsUnicode(false)
                   .HasColumnName("ENDERECO");

            builder.Property(x => x.Modalidade)
                   .HasColumnName("MODALIDADE");

            builder.Property(x => x.Observacao)
                   .HasMaxLength(2000)
                   .IsUnicode(false)
                   .HasColumnName("OBSERVACAO");

            builder.Property(x => x.EntidadeId)
                   .HasColumnName("ENTIDADEID");

            builder.Property(x => x.TipoVinculo)
                   .HasColumnName("TIPOVINCULO");

            builder.HasMany(x => x.GrupoEventoResponsavel)
                   .WithOne(x => x.Evento)
                   .HasForeignKey(x => x.EventoId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_EVENTO_EVENTORESPONSAVEL");
        }
    }
}
