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
    public class WebJurVisualizacaoMap : IEntityTypeConfiguration<WebJurVisualizacao>
    {
        public void Configure(EntityTypeBuilder<WebJurVisualizacao> builder)
        {
            builder.ToTable("WebJurVisualizacao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataVisualizacao)
                .IsRequired();

            builder.Property(x => x.Ip)
                .HasMaxLength(50);

            builder.HasOne(x => x.WebJurPublicacao)
                .WithMany(x => x.Visualizacoes)
                .HasForeignKey(x => x.WebJurPublicacaoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
