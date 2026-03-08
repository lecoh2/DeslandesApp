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
    public class LoginHistoryMap : IEntityTypeConfiguration<LoginHistory>
    {
        public void Configure(EntityTypeBuilder<LoginHistory> builder)
        {
            builder.ToTable("LOGINHISTORY");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IpAcesso).HasColumnName("IPACESSO").HasMaxLength(45);
            builder.Property(x => x.UserAgent).HasColumnName("USERAGENT").HasMaxLength(300);
            builder.Property(x => x.Mensagem).HasColumnName("MENSAGEM").HasMaxLength(300);

            builder.HasOne(x => x.Usuario)
                .WithMany() // ou .WithMany(u => u.LoginHistory) se quiser navegação reversa
                .HasForeignKey(x => x.IdUsuario);
        }
    }
}