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
    public class AcaoMap : IEntityTypeConfiguration<Acao>
    {
        public void Configure(EntityTypeBuilder<Acao> builder)
        {
            builder.ToTable("ACAO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NomeAcao)
                .HasColumnName("NOMEACAO")
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}