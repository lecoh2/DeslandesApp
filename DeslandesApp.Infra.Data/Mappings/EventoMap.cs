using DeslandesApp.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Infra.Data.Mappings
{
    using Microsoft.EntityFrameworkCore.ChangeTracking;

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

            // 🔁 RECORRÊNCIA
            builder.Property(x => x.TipoRecorrencia)
                   .HasColumnName("TIPORECORRENCIA");

            builder.Property(x => x.IntervaloRecorrencia)
                   .HasColumnName("INTERVALORECORRENCIA");

            builder.Property(x => x.DataFimRecorrencia)
                   .HasColumnName("DATAFIMRECORRENCIA");

            builder.Property(x => x.QuantidadeOcorrencias)
                   .HasColumnName("QUANTIDADEOCORRENCIAS");

            builder.Property(x => x.DiasSemana)
                   .HasColumnName("DIASSEMANA")
                   .HasConversion(
                       v => string.Join(",", v),
                       v => string.IsNullOrEmpty(v)
                            ? new List<DayOfWeek>()
                            : v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                               .Select(x => Enum.Parse<DayOfWeek>(x))
                               .ToList()
                   )
                   .Metadata.SetValueComparer(new ValueComparer<List<DayOfWeek>>(
                       (c1, c2) => c1.SequenceEqual(c2),
                       c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                       c => c.ToList()
                   ));

            // 👥 Responsáveis (N:N)
            builder.HasMany(x => x.GrupoEventoResponsavel)
                   .WithOne(x => x.Evento)
                   .HasForeignKey(x => x.EventoId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_EVENTO_EVENTORESPONSAVEL");
            builder.HasOne(e => e.UsuarioCriacao)
              .WithMany()
              .HasForeignKey(e => e.UsuarioCriacaoId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
