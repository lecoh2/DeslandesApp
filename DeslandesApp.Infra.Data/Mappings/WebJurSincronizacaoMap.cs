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
    public class WebJurSincronizacaoMap : IEntityTypeConfiguration<WebJurSincronizacao>
    {
        public void Configure(EntityTypeBuilder<WebJurSincronizacao> builder)
        {
            builder.ToTable("WebJurSincronizacao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Inicio)
                .IsRequired();

            builder.Property(x => x.Mensagem)
                .HasMaxLength(2000);

            builder.Property(x => x.Sucesso)
                .IsRequired();

            builder.HasOne(x => x.WebJurPublicacao)
                .WithMany(x => x.Sincronizacoes)
                .HasForeignKey(x => x.WebJurPublicacaoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
