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
    public class CategoriaFinanceiraMap : IEntityTypeConfiguration<CategoriaFinanceira>
    {
        public void Configure(EntityTypeBuilder<CategoriaFinanceira> builder)
        {
            builder.ToTable("CATEGORIA_FINANCEIRA");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Tipo)
                .IsRequired();

            builder.HasQueryFilter(x => !x.Excluido);
        }
    }
}
