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
    public class FotosMap : IEntityTypeConfiguration<Fotos>
    {
        public void Configure(EntityTypeBuilder<Fotos> builder)
        {
            builder.ToTable("FOTOS");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.IdUsuario).HasColumnName("USUARIO_ID");
            builder.Property(u => u.FotoNome).HasColumnName("FOTONOME");
            builder.Property(u => u.DataCadastro).HasColumnName("DATACADASTRO");
            builder.Property(u => u.DataAtualizacao).HasColumnName("DATAATUALIZACAO");


            #region Relacionamento com Pessoa
            builder.HasOne(f => f.Usuario)
        .WithOne(u => u.Fotos)
        .HasForeignKey<Fotos>(f => f.IdUsuario);
            #endregion
        }
    }
}
