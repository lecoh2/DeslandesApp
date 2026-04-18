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
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("TAREFA");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                   .HasMaxLength(500)
                   .IsUnicode(false)
                   .HasColumnName("DESCRICAO");

            builder.Property(x => x.DataCadastro)
                   .HasColumnName("DATACADASTRO")
                   .IsRequired();
     

            builder.Property(x => x.TipoVinculo)
                   .HasColumnName("TIPOVINCULO");
            builder.Property(x => x.DataAtualizacao)
                   .HasColumnName("DATAATUALIZACAO");

            builder.Property(x => x.DataTarefa)
                   .HasColumnName("DATATAREFA");

            builder.Property(x => x.ProcessoId).HasColumnName("PROCESSOID");
            builder.HasOne(x => x.Processo)
                   .WithMany()
                   .HasForeignKey(x => x.ProcessoId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_TAREFA_PROCESSO");

            builder.Property(x => x.CasoId).HasColumnName("CASOID");
            builder.HasOne(x => x.Caso)
                   .WithMany()
                   .HasForeignKey(x => x.CasoId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_TAREFA_CASO");

            builder.Property(x => x.AtendimentoId).HasColumnName("ATENDIMENTOID");
            builder.HasOne(x => x.Atendimento)
                   .WithMany()
                   .HasForeignKey(x => x.AtendimentoId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_TAREFA_ATENDIMENTO");
            // 👤 Responsável
            //builder.Property(x => x.ResponsavelId)
            //       .HasColumnName("RESPONSAVELID");

            //builder.HasOne(x => x.Responsavel)
            //       .WithMany()
            //       .HasForeignKey(x => x.ResponsavelId)
            //       .OnDelete(DeleteBehavior.Restrict)
            //       .HasConstraintName("FK_TAREFA_USUARIO");

            builder.Property(x => x.Prioridade)
                   .HasColumnName("PRIORIDADE");

            // 📋 Checklist
            builder.HasMany(x => x.ListasTarefa)
                   .WithOne(x => x.Tarefa)
                   .HasForeignKey(x => x.TarefaId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_TAREFA_LISTATAREFA");

            // 👥 Envolvidos
            builder.HasMany(x => x.GrupoTarefaResponsaveis)
                   .WithOne(x => x.Tarefa)
                   .HasForeignKey(x => x.TarefaId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_TAREFA_RESPONSAVEIS");
            builder.HasOne(e => e.UsuarioCriacao)
                .WithMany()
                .HasForeignKey(e => e.UsuarioCriacaoId)
                .OnDelete(DeleteBehavior.Restrict);
            // 🔥 STATUS KANBAN
            builder.Property(x => x.StatusGeralKanban)
                .HasColumnName("STATUSKANBAN")
                .IsRequired();
        }
    }
}

