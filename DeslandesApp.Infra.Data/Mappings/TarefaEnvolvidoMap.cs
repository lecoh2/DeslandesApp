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
    public class TarefaResponsaveisMap : IEntityTypeConfiguration<GrupoTarefaResponsaveis>
    {
        public void Configure(EntityTypeBuilder<GrupoTarefaResponsaveis> builder)
        {
            builder.ToTable("GRUPOTAREFARESPONSAVEIS");


            builder.HasKey(x => new { x.UsuarioId,  x.TarefaId });

            builder.HasOne(x => x.Usuario)
                   .WithMany(x => x.GrupoTarefaResponsaveis)
                   .HasForeignKey(x => x.UsuarioId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_TAREFARESPONSAVEIS_Usuario");

            builder.HasOne(x => x.Tarefa)
                   .WithMany(x => x.GrupoTarefaResponsaveis)
                   .HasForeignKey(x => x.TarefaId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_TAREFARESPONSAVEIS_TAREFA");

            // 🔥 Evita duplicidade
            builder.HasIndex(x => new { x.TarefaId, x.UsuarioId })
                   .IsUnique();
        }
    }
}
