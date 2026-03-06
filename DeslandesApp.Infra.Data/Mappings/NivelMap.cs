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
    public class NivelMap : IEntityTypeConfiguration<Niveis>
    {
        public void Configure(EntityTypeBuilder<Niveis> builder)
        {
            builder.ToTable("NIVEL");
            builder.HasKey(n => n.Id);           
            builder.Property(n => n.NomeNivel).HasColumnName("NOMENIVEL").IsRequired();
            // builder.Property(n => n.Status).HasColumnName("STATUS").IsRequired();
        }
    }
}

