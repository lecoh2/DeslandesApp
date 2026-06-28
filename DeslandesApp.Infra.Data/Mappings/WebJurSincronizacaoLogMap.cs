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
    public class WebJurSincronizacaoLogMap : IEntityTypeConfiguration<WebJurSincronizacaoLog>
    {
        public void Configure(EntityTypeBuilder<WebJurSincronizacaoLog> builder)
        {
            builder.ToTable("WebJurSincronizacaoLog");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.DataExecucao)
                .IsRequired();

            builder.Property(x => x.TotalRecebidos)
                .IsRequired();

            builder.Property(x => x.TotalImportados)
                .IsRequired();

            builder.Property(x => x.TotalFalhas)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.MensagemErro)
                .HasMaxLength(2000);
        }
    }
}
