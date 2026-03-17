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
    public class QualificacaoMap : IEntityTypeConfiguration<Qualificacao>
    {
        public void Configure(EntityTypeBuilder<Qualificacao> builder)
        {
            builder.ToTable("QUALIFICACAO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NomeQualificacao)
                .HasColumnName("NOMEQUALIFICACAO")
                .HasMaxLength(150)
                .IsRequired();

            // 🔗 RELACIONAMENTO COM PROCESSO
            builder.HasOne(q => q.Processo)
                   .WithMany(p => p.Qualificacao)
                   .HasForeignKey(q => q.Id)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}