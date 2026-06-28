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
    public class WebJurComentarioMap : IEntityTypeConfiguration<WebJurComentario>
    {
        public void Configure(EntityTypeBuilder<WebJurComentario> builder)
        {
            builder.ToTable("WebJurComentario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Comentario)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(x => x.DataCadastro)
                .IsRequired();

            builder.HasOne(x => x.WebJurPublicacao)
                .WithMany(x => x.Comentarios)
                .HasForeignKey(x => x.WebJurPublicacaoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
