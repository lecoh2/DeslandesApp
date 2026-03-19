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
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("TAREFA");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                   .HasMaxLength(500)
                   .IsUnicode(false)
                   .HasColumnName("DESCRICAO");

            builder.Property(x => x.DataCadastro)
                   .HasColumnName("DATA");

            builder.HasMany(x => x.Listas)
                   .WithOne(x => x.Tarefa)
                   .HasForeignKey(x => x.TarefaId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_TAREFA_LISTATAREFA");
        }
    }
}
