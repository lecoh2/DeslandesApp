using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeslandesApp.Infra.Data.Mappings
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("PESSOA");

            builder.HasKey(p => p.Id);

            // =========================
            // 📌 CAMPOS
            // =========================
            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .IsRequired();

            builder.Property(p => p.Apelido)
                .HasColumnName("APELIDO")
                .IsRequired(false);

            builder.Property(p => p.DataCadastro)
                .HasColumnName("DATACADASTRO")
                .IsRequired();

            builder.Property(p => p.DataAtualizacao)
                .HasColumnName("DATAATUALIZACAO");

            builder.Property(p => p.IdUsuario)
                .HasColumnName("USUARIO_ID")
                .IsRequired();

            builder.Property(p => p.ValorEmail)
                .HasConversion(
                    v => v == null ? null : v.EnderecoEmail,
                    v => v == null ? null : new ValorEmail(v))
                .HasColumnName("EMAIL")
                .HasMaxLength(150)
                .IsRequired(false);

            // =========================
            // 🔗 RELACIONAMENTO USUÁRIO
            // =========================
            builder.HasOne(p => p.Usuario)
                .WithMany(u => u.Pessoa)
                .HasForeignKey(p => p.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            // =========================
            // 👥 ATENDIMENTO CLIENTES
            // =========================
            builder.HasMany(p => p.GrupoPessoaClientes)
                .WithOne(g => g.Pessoa)
                .HasForeignKey(g => g.PessoaId)
                .OnDelete(DeleteBehavior.Restrict);

            // =========================
            // ⚖️ CASO ENVOLVIDOS
            // =========================
            builder.HasMany(p => p.GrupoCasoEnvolvidos)
                .WithOne(g => g.Pessoa)
                .HasForeignKey(g => g.PessoaId)
                .OnDelete(DeleteBehavior.Restrict);

            // =========================
            // 🏷️ ETIQUETAS DA PESSOA
            // =========================
            builder.HasMany(p => p.GrupoPessoasEtiquetas)
                .WithOne(g => g.Pessoa)
                .HasForeignKey(g => g.PessoaId)
                .OnDelete(DeleteBehavior.Cascade);

            // =========================
            // 📂 PROCESSO ENVOLVIDOS
            // =========================
            builder.HasMany(p => p.GrupoEnvolvidosProcesso)
                .WithOne(g => g.Pessoa)
                .HasForeignKey(g => g.PessoaId)
                .OnDelete(DeleteBehavior.Restrict);

            // =========================
            // 🧬 HERANÇA
            // =========================
            builder.HasDiscriminator<string>("TIPO")
                .HasValue<PessoaFisica>("PESSOAFISICA")
                .HasValue<PessoaJuridica>("PESSOAJURIDICA");
        }
    }
}