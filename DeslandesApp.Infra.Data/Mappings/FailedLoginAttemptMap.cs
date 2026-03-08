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
    public class FailedLoginAttemptMap : IEntityTypeConfiguration<FailedLoginAttempt>
    {
        public void Configure(EntityTypeBuilder<FailedLoginAttempt> builder)
        {
            builder.ToTable("FAILEDLOGINATTEMPTS");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id).HasColumnName("IDFAILEDLOGINATTEMPT").ValueGeneratedNever(); // já vem com Guid.NewGuid()

            builder.Property(f => f.IdUsuario).HasColumnName("IDUSUARIO") .IsRequired(false); // FK opcional

            builder.Property(f => f.Login).HasColumnName("LOGIN").HasMaxLength(150)
                .IsUnicode(false).IsRequired();

            builder.Property(f => f.IpAcesso) .HasColumnName("IPACESSO") .HasMaxLength(50) .IsUnicode(false);

            builder.Property(f => f.UserAgent)  .HasColumnName("USERAGENT") .HasMaxLength(300) .IsUnicode(false);

            builder.Property(f => f.DataHora).HasColumnName("DATAHORA") .IsRequired();

            builder.Property(f => f.Mensagem) .HasColumnName("MENSAGEM")  .HasMaxLength(200).IsUnicode(false);

            // Relação opcional com Usuario
            builder.HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(f => f.IdUsuario)
                .OnDelete(DeleteBehavior.NoAction); // evita erro se IdUsuario for null
        }
    }
}