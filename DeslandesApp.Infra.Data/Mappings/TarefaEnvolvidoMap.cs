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
    public class TarefaEnvolvidoMap : IEntityTypeConfiguration<GrupoTarefaEnvolvido>
    {
        public void Configure(EntityTypeBuilder<GrupoTarefaEnvolvido> builder)
        {
            builder.ToTable("GRUPOTAREFAENVOLVIDO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UsuarioId)
                   .HasColumnName("USUARIOID");

            builder.Property(x => x.TarefaId)
                   .HasColumnName("TAREFAID");

            builder.HasOne(x => x.Usuario)
                   .WithMany()
                   .HasForeignKey(x => x.UsuarioId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_TAREFAENVOLVIDO_USUARIO");

            builder.HasOne(x => x.Tarefa)
                   .WithMany(x => x.GrupoTarefaEnvolvido)
                   .HasForeignKey(x => x.TarefaId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_TAREFAENVOLVIDO_TAREFA");
        }
    }
}
