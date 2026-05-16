using DeslandesApp.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeslandesApp.Infra.Data.Mappings
{
    public class NotificacaoMap : IEntityTypeConfiguration<Notificacao>
    {
        public void Configure(EntityTypeBuilder<Notificacao> builder)
        {
            builder.ToTable("NOTIFICACAO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UsuarioId)
                .IsRequired();

            builder.Property(x => x.Titulo)
                .HasColumnName("TITULO")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Mensagem)
                .HasColumnName("MENSAGEM")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.Lida)
                .HasColumnName("LIDA")
                .IsRequired();

            builder.Property(x => x.DataCriacao)
                .HasColumnName("DATACRIACAO")
                .IsRequired();

            // 🔥 NOVOS CAMPOS (se você adicionou na entity)

            builder.Property(x => x.Tipo)
                .HasColumnName("TIPO")
                .HasMaxLength(50);

            builder.Property(x => x.Link)
                .HasColumnName("LINK")
                .HasMaxLength(500);

            builder.Property(x => x.EntidadeId)
                .HasColumnName("ENTIDADEID");

            // 🔗 RELAÇÃO COM USUÁRIO (opcional mas recomendado)
            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}