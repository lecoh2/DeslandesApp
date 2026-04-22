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


public class ComentarioMap : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.ToTable("Comentarios");

            // 🔑 PK
            builder.HasKey(c => c.Id);

            // 📝 TEXTO
            builder.Property(c => c.Texto)
                .IsRequired()
                .HasMaxLength(1000);

            // 📅 DATA
            builder.Property(c => c.DataCriacao)
                .IsRequired();

            // 🔗 USUÁRIO (N:1)
            builder.HasOne(c => c.Usuario)
                .WithMany() // se quiser depois pode criar coleção em Usuario
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔗 TAREFA (N:1 opcional)
            builder.HasOne(c => c.Tarefa)
                .WithMany() // ou .WithMany(t => t.Comentarios)
                .HasForeignKey(c => c.TarefaId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔗 EVENTO (N:1 opcional)
            builder.HasOne(c => c.Evento)
                .WithMany() // ou .WithMany(e => e.Comentarios)
                .HasForeignKey(c => c.EventoId)
                .OnDelete(DeleteBehavior.Cascade);

            // ⚠️ IMPORTANTE: evitar duplicidade de vínculo
            builder.HasCheckConstraint(
                "CK_Comentario_Vinculo",
                "[TarefaId] IS NOT NULL OR [EventoId] IS NOT NULL"
            );
        }
    }
}

