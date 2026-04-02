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
    public class EventoHistoricoMap : IEntityTypeConfiguration<EventoHistorico>
    {
        public void Configure(EntityTypeBuilder<EventoHistorico> builder)
        {
            builder.ToTable("EVENTOHISTORICO");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.EventoId)
                .HasColumnName("EVENTO_ID")
                .IsRequired();

            builder.Property(a => a.UsuarioId)
                .HasColumnName("USUARIO_ID");

            builder.Property(a => a.DataAlteracao)
                .HasColumnName("DATAALTERACAO")
                .IsRequired(false);

            builder.Property(a => a.Observacao)
                .HasColumnName("OBSERVACAO")
                .HasColumnType("VARCHAR(255)")
                .IsRequired(false);

            builder.Property(a => a.DadosAntes)
                .HasColumnName("DADOSANTES")
                .HasColumnType("VARCHAR(MAX)")
                .IsRequired(false);

            builder.Property(a => a.DadosDepois)
                .HasColumnName("DADOSDEPOIS")
                .HasColumnType("VARCHAR(MAX)")
                .IsRequired(false);

            // 🔗 Relacionamento com Atendimento
            builder.HasOne(a => a.Evento)
                .WithMany()
                .HasForeignKey(a => a.EventoId)
                .HasConstraintName("FK_EventoHistorico_Evento")
                .OnDelete(DeleteBehavior.Restrict);

            // 🔗 Relacionamento com Usuario
            builder.HasOne(a => a.Usuario)
                .WithMany()
                .HasForeignKey(a => a.UsuarioId)
                .HasConstraintName("FK_EventoHistorico_Usuario")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
