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
   
        public class ContaReceberBaixaMap
    : IEntityTypeConfiguration<ContaReceberBaixa>
        {
            public void Configure(
                EntityTypeBuilder<ContaReceberBaixa> builder)
            {
                builder.ToTable("ContaReceberBaixa");

                builder.HasKey(x => x.Id);

                builder.Property(x => x.ValorPago)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                builder.Property(x => x.DataBaixa)
                    .IsRequired();

                builder.Property(x => x.FormaRecebimento)
                    .IsRequired();

                builder.Property(x => x.Observacao)
                    .HasMaxLength(1000);

            builder.HasOne(x => x.ContaReceber)
                .WithMany(x => x.Baixas)
                .HasForeignKey(x => x.ContaReceberId);
        }
        }

    }

