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
    public class WebJurMovimentacaoMap : IEntityTypeConfiguration<WebJurMovimentacao>
    {
        public void Configure(EntityTypeBuilder<WebJurMovimentacao> builder)
        {
            builder.ToTable("WebJurMovimentacao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tipo)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(4000);

            builder.Property(x => x.Origem)
                .HasMaxLength(100);

            builder.Property(x => x.DataMovimentacao)
                .IsRequired();

            builder.HasOne(x => x.WebJurPublicacao)
                .WithMany(x => x.Movimentacoes)
                .HasForeignKey(x => x.WebJurPublicacaoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
