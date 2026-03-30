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
   
        public class GrupoTarefaResponsaveisMap : IEntityTypeConfiguration<GrupoTarefaResponsaveis>
        {
            public void Configure(EntityTypeBuilder<GrupoTarefaResponsaveis> builder)
            {
                builder.ToTable("GRUPOTAREFARESPONSAVEIS");

            // 🔑 PK
            builder.HasKey(x => new { x.PessoaId, x.TarefaId });

            builder.HasOne(x => x.Tarefa)
                       .WithMany(x => x.GrupoTarefaResponsaveis)
                       .HasForeignKey(x => x.TarefaId)
                       .OnDelete(DeleteBehavior.Cascade)
                       .HasConstraintName("FK_GRUPOTAREFA_TAREFA");

                // 🔗 FK - Pessoa
                builder.Property(x => x.PessoaId)
                       .HasColumnName("PESSOAID")
                       .IsRequired();

                builder.HasOne(x => x.Pessoa)
                       .WithMany(x => x.GrupoTarefaResponsaveis)
                       .HasForeignKey(x => x.PessoaId)
                       .OnDelete(DeleteBehavior.Restrict)
                       .HasConstraintName("FK_GRUPOTAREFA_PESSOA");
            }
        }
    }

