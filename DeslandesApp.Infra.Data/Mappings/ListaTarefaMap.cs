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
    public class ListaTarefaMap : IEntityTypeConfiguration<ListaTarefa>
    {
                
            public void Configure(EntityTypeBuilder<ListaTarefa> builder)
            {
                builder.ToTable("LISTATAREFA");

                builder.HasKey(x => x.Id);

                builder.Property(x => x.Descricao)
                       .HasColumnName("DESCRICAO")
                       .HasMaxLength(300)
                       .IsRequired();

            builder.Property(x => x.Concluida)
   .HasColumnName("CONCLUIDA");

            builder.Property(x => x.DataConclusao)
                       .HasColumnName("DATACONCLUSAO").IsRequired(false);

            builder.Property(x => x.Ordem)
                       .HasColumnName("ORDEM").IsRequired(false);

            builder.Property(x => x.TarefaId)
                       .HasColumnName("TAREFAID")
                       .IsRequired(false);

                builder.HasOne(x => x.Tarefa)
                       .WithMany(x => x.ListasTarefa)
                       .HasForeignKey(x => x.TarefaId)
                       .OnDelete(DeleteBehavior.Cascade)
                       .HasConstraintName("FK_LISTATAREFA_TAREFA");
            }
        }
    }
    

