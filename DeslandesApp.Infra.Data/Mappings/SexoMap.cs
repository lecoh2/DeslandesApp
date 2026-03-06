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
    public class SexoMap : IEntityTypeConfiguration<Sexo>
    {
        public void Configure(EntityTypeBuilder<Sexo> builder)
        {
            builder.ToTable("SEXO");
            builder.HasKey(s => s.Id);
          
            builder.Property(s => s.NomeSexo).HasColumnName("NOMESEXO").HasMaxLength(100).IsRequired();
            builder.HasIndex(s => s.NomeSexo).IsUnique();
        }
    }
}