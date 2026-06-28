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
    public class WebJurPublicacaoMap : IEntityTypeConfiguration<WebJurPublicacao>
    {
        public void Configure(EntityTypeBuilder<WebJurPublicacao> builder)
        {
            builder.ToTable("WEBJURPUBLICACAO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CodPublicacao)
                .IsRequired();

            builder.Property(x => x.NumeroProcesso)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.DataPublicacao)
                .IsRequired();

            builder.Property(x => x.DataCadastroWebJur)
                .IsRequired();

            builder.Property(x => x.DespachoPublicacao)
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.ProcessoPublicacao)
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.VaraDescricao)
                .HasMaxLength(200);

            builder.Property(x => x.OrgaoDescricao)
                .HasMaxLength(200);

            builder.Property(x => x.PublicacaoCorrigida)
                .HasDefaultValue(false);

            builder.Property(x => x.Importada)
                .HasDefaultValue(false);

            // Relacionamento opcional com Processo
            builder.HasOne(x => x.Processo)
                .WithMany()
                .HasForeignKey(x => x.ProcessoId)
                .OnDelete(DeleteBehavior.SetNull);

            // Índice para evitar duplicidade de publicações
            builder.HasIndex(x => x.CodPublicacao)
                .IsUnique();

            // Navegações (não carregar automaticamente)
            builder.Navigation(x => x.Comentarios)
                .AutoInclude(false);

            builder.Navigation(x => x.Movimentacoes)
                .AutoInclude(false);

            builder.Navigation(x => x.Arquivos)
                .AutoInclude(false);

            builder.Navigation(x => x.Visualizacoes)
                .AutoInclude(false);

            builder.Navigation(x => x.Sincronizacoes)
                .AutoInclude(false);
        }
    }
}
