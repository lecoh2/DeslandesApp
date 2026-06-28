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
    public class WebJurArquivoMap : IEntityTypeConfiguration<WebJurArquivo>
    {
        public void Configure(EntityTypeBuilder<WebJurArquivo> builder)
        {
            builder.ToTable("WebJurArquivo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NomeArquivo)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(x => x.CaminhoArquivo)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(x => x.TipoArquivo)
                .HasMaxLength(50);

            builder.Property(x => x.DataCadastro)
                .IsRequired();

            builder.HasOne(x => x.WebJurPublicacao)
                .WithMany(x => x.Arquivos)
                .HasForeignKey(x => x.WebJurPublicacaoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
