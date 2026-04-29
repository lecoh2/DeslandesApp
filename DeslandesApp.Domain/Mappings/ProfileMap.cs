using AutoMapper;
using DeslandesApp.Domain.Models.Dtos.Requests.Atendimento;
using DeslandesApp.Domain.Models.Dtos.Requests.Caso;
using DeslandesApp.Domain.Models.Dtos.Requests.Comentarios;
using DeslandesApp.Domain.Models.Dtos.Requests.ContaBancaria;
using DeslandesApp.Domain.Models.Dtos.Requests.EnderecoPessoa;
using DeslandesApp.Domain.Models.Dtos.Requests.Evento;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoCasoCliente;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoCasoEnvolvidos;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoClienteProceso;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEtiquetaProcesso;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoEventoEtiquetas;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoNiveis;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoSetores;
using DeslandesApp.Domain.Models.Dtos.Requests.InformacoesComplementares;
using DeslandesApp.Domain.Models.Dtos.Requests.Nivel;
using DeslandesApp.Domain.Models.Dtos.Requests.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Requests.Processo;
using DeslandesApp.Domain.Models.Dtos.Requests.Setor;
using DeslandesApp.Domain.Models.Dtos.Requests.Tarefa;
using DeslandesApp.Domain.Models.Dtos.Requests.Usuarios;
using DeslandesApp.Domain.Models.Dtos.Requests.Usuarios;
using DeslandesApp.Domain.Models.Dtos.Responses.Agenda;
using DeslandesApp.Domain.Models.Dtos.Responses.Atendimento;
using DeslandesApp.Domain.Models.Dtos.Responses.Caso;
using DeslandesApp.Domain.Models.Dtos.Responses.EnderecoEndereco;
using DeslandesApp.Domain.Models.Dtos.Responses.Etiquetas;
using DeslandesApp.Domain.Models.Dtos.Responses.Evento;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoAtendimentoCliente;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoCasoCliente;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoCasoEnvolvidos;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEnvolvidosProcesso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEtiquetaAtendimento;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEtiquetaCaso;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEtiquetasProcessos;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEventoEtiquetas;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoEventoResponsavel;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoNiveis;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoPessoasEtiquetas;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoSetores;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoTarefaResponsaveis;
using DeslandesApp.Domain.Models.Dtos.Responses.InformacoesComplementares;
using DeslandesApp.Domain.Models.Dtos.Responses.ListaTarefas;
using DeslandesApp.Domain.Models.Dtos.Responses.Nivel;
using DeslandesApp.Domain.Models.Dtos.Responses.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
using DeslandesApp.Domain.Models.Dtos.Responses.Qualificacao;
using DeslandesApp.Domain.Models.Dtos.Responses.Setor;
using DeslandesApp.Domain.Models.Dtos.Responses.Tarefa;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios.DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Models.Dtos.Responses.Vara;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.ValueObjects;
using System.Runtime.ConstrainedExecution;
using ObterTarefaResponse = DeslandesApp.Domain.Models.Dtos.Responses.Tarefa.ObterTarefaResponse;

namespace DeslandesApp.Domain.Mappings
{
    public class ProfileMap : Profile
    {
        public ProfileMap()
        {

            #region USUARIOS

            CreateMap<UsuariosRequest, Usuario>()
                .ForMember(dest => dest.ValorEmail,
                    opt => opt.MapFrom(src =>
                        string.IsNullOrEmpty(src.Email)
                            ? null
                            : new ValorEmail(src.Email)));

            CreateMap<UsuarioUpdateRequest, Usuario>()
                .ForMember(dest => dest.ValorEmail,
                    opt => opt.MapFrom(src =>
                        string.IsNullOrEmpty(src.Email)
                            ? null
                            : new ValorEmail(src.Email)));

            CreateMap<Usuario, UsuariosResponse>()
                .ForCtorParam("Email",
                    opt => opt.MapFrom(src =>
                        src.ValorEmail != null
                            ? src.ValorEmail.EnderecoEmail
                            : null));

            #endregion


            #region SETOR

            CreateMap<SetorRequest, Setor>();

            CreateMap<Setor, SetorResponse>()
                .ForCtorParam("IdSetor", opt => opt.MapFrom(src => src.Id))
                .ForCtorParam("NomeSetor", opt => opt.MapFrom(src => src.NomeSetor));

            #endregion


            #region NIVEL

            CreateMap<NivelRequest, Niveis>();

            CreateMap<Niveis, NivelResponse>()
                .ForCtorParam("IdNivel", opt => opt.MapFrom(src => src.Id))
                .ForCtorParam("NomeNivel", opt => opt.MapFrom(src => src.NomeNivel));

            #endregion


            #region GRUPO NIVEIS

            CreateMap<GrupoNivelRequest, GrupoNiveis>();
            CreateMap<GrupoNiveis, GrupoNivelResponse>();

            #endregion


            #region GRUPO SETORES

            CreateMap<GrupoSetorRequest, GrupoSetores>();
            CreateMap<GrupoSetores, GrupoSetorResponse>();

            #endregion


            #region PESSOA JURIDICA

            CreateMap<PessoaJuridicaRequest, PessoaJuridica>()
       .ForMember(dest => dest.ValorEmail,
           opt => opt.MapFrom(src =>
               string.IsNullOrEmpty(src.Email)
                   ? null
                   : ValorEmail.Create(src.Email)))
       .ForMember(dest => dest.InformacoesComplementares, opt => opt.Ignore())
       .ForMember(dest => dest.GrupoPessoasEtiquetas, opt => opt.Ignore()); // 🔥 PADRÃO

            CreateMap<PessoaJuridicaUpdateRequest, PessoaJuridica>()
                .ForMember(dest => dest.ValorEmail,
                    opt => opt.MapFrom(src =>
                        string.IsNullOrEmpty(src.Email)
                            ? null
                            : ValorEmail.Create(src.Email)))
                .ForMember(dest => dest.InformacoesComplementares, opt => opt.Ignore())
                .ForMember(dest => dest.Endereco, opt => opt.Ignore())
                .ForMember(dest => dest.GrupoPessoasEtiquetas, opt => opt.Ignore()); // 🔥 PADRÃO

            CreateMap<PessoaJuridica, PessoaJuridicaResponse>()
                .ForCtorParam("Email",
                    opt => opt.MapFrom(src =>
                        src.ValorEmail != null
                            ? src.ValorEmail.EnderecoEmail
                            : null));

            #endregion

            #region pessoas pf pj
            CreateMap<PessoaFisica, PessoaResumoResponse>()
    .ForMember(dest => dest.Documento, opt => opt.MapFrom(src => src.CPF))
    .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => "Fisica"));

            CreateMap<PessoaJuridica, PessoaResumoResponse>()
                .ForMember(dest => dest.Documento, opt => opt.MapFrom(src => src.CNPJ))
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => "Juridica"));
            #endregion
            #region PESSOA FISICA

            CreateMap<PessoaFisicaRequest, PessoaFisica>()
                .ForMember(dest => dest.ValorEmail,
                    opt => opt.MapFrom(src =>
                        string.IsNullOrEmpty(src.Email)
                            ? null
                            : new ValorEmail(src.Email)))
                .ForMember(dest => dest.InformacoesComplementares, opt => opt.Ignore())
                .ForMember(dest => dest.GrupoPessoasEtiquetas, opt => opt.Ignore()); // 🔥 AQUI

            CreateMap<PessoaFisicaUpdateRequest, PessoaFisica>()
                 .ForMember(dest => dest.ValorEmail,
        opt => opt.MapFrom(src =>
            string.IsNullOrEmpty(src.Email)
                ? null
                : ValorEmail.Create(src.Email))) // 🔥 FALTAVA ISSO
                .ForMember(dest => dest.InformacoesComplementares, opt => opt.Ignore())
                .ForMember(dest => dest.Endereco, opt => opt.Ignore())
                .ForMember(dest => dest.GrupoPessoasEtiquetas, opt => opt.Ignore()); // 🔥 BOA PRÁTICA

            CreateMap<PessoaFisica, PessoaFisicaResponse>()
                .ForCtorParam("Email",
                    opt => opt.MapFrom(src =>
                        src.ValorEmail != null
                            ? src.ValorEmail.EnderecoEmail
                            : null));

            #endregion


            #region INFORMACOES COMPLEMENTARES

            CreateMap<InformacoesComplementaresRequest,
                InformacoesComplementaresPessoaFisica>();

            CreateMap<InformacoesComplementaresPessoaFisica,
                InformacoesComplementaresResponse>();

            CreateMap<InformacoesComplementaresJuridicaRequest,
                InformacoesComplementaresPessoaJuridica>();

            CreateMap<InformacoesComplementaresPessoaJuridica,
                InformacoesComplementaresResponse>();

            #endregion


            #region ENDERECO

            CreateMap<EnderecoRequest, Endereco>();
            CreateMap<Endereco, EnderecoResponse>();

            #endregion

            #region Processo
            #region Processo

            // =========================
            // CREATE
            // =========================
            CreateMap<ProcessoRequest, Processo>()
                .ForMember(dest => dest.Vara, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioResponsavel, opt => opt.Ignore())
                .ForMember(dest => dest.Acao, opt => opt.Ignore())
                .ForMember(dest => dest.GrupoClienteProcesso, opt => opt.Ignore())
                .ForMember(dest => dest.GrupoEnvolvidosProcesso, opt => opt.Ignore())
                .ForMember(dest => dest.GrupoEtiquetasProcessos, opt => opt.Ignore());

            // =========================
            // UPDATE
            // =========================
            CreateMap<ProcessoUpdateRequest, Processo>()
                .ForMember(dest => dest.GrupoClienteProcesso, opt => opt.Ignore())
                .ForMember(dest => dest.GrupoEnvolvidosProcesso, opt => opt.Ignore())
                .ForMember(dest => dest.GrupoEtiquetasProcessos, opt => opt.Ignore());

            // =========================
            // RESPONSE PRINCIPAL
            // =========================
            CreateMap<Processo, ObterProcessoResponse>()
                .ForMember(dest => dest.AcaoId,
                    opt => opt.MapFrom(src => src.AcaoId))

                .ForMember(dest => dest.VaraId,
                    opt => opt.MapFrom(src => src.VaraId))

                .ForMember(dest => dest.UsuarioResponsavelId,
                    opt => opt.MapFrom(src => src.UsuarioResponsavelId))

                // 🔥 CAMPOS SIMPLES
                .ForMember(dest => dest.Pasta, opt => opt.MapFrom(src => src.Pasta))
                .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
                .ForMember(dest => dest.NumeroProcesso, opt => opt.MapFrom(src => src.NumeroProcesso))
                .ForMember(dest => dest.LinkTribunal, opt => opt.MapFrom(src => src.LinkTribunal))
                .ForMember(dest => dest.Objeto, opt => opt.MapFrom(src => src.Objeto))
                .ForMember(dest => dest.ValorCausa, opt => opt.MapFrom(src => src.ValorCausa))
                .ForMember(dest => dest.Distribuido, opt => opt.MapFrom(src => src.Distribuido))
                .ForMember(dest => dest.ValorCondenacao, opt => opt.MapFrom(src => src.ValorCondenacao))
                .ForMember(dest => dest.Observacao, opt => opt.MapFrom(src => src.Observacao))
                .ForMember(dest => dest.Instancia, opt => opt.MapFrom(src => src.Instancia))
                .ForMember(dest => dest.Acesso, opt => opt.MapFrom(src => src.Acesso))

                // 🔥 RELACIONAMENTOS
                .ForMember(dest => dest.GrupoClienteProcesso,
                    opt => opt.MapFrom(src => src.GrupoClienteProcesso))

                .ForMember(dest => dest.GrupoEnvolvidosProcesso,
                    opt => opt.MapFrom(src => src.GrupoEnvolvidosProcesso))

                .ForMember(dest => dest.GrupoEtiquetasProcesso,
                    opt => opt.MapFrom(src => src.GrupoEtiquetasProcessos));


            // =========================
            // CLIENTES
            // =========================
            CreateMap<GrupoClienteProcesso, GrupoClienteProcessoRequest>()
                .ForMember(dest => dest.IdPessoa,
                    opt => opt.MapFrom(src => src.PessoaId));


            // =========================
            // ENVOLVIDOS
            // =========================
            CreateMap<GrupoEnvolvidosProcesso, GrupoEnvolvidosProcessoResponse>()
                .ForMember(dest => dest.IdPessoa,
                    opt => opt.MapFrom(src => src.PessoaId))

                .ForMember(dest => dest.Nome,
                    opt => opt.MapFrom(src => src.Pessoa != null ? src.Pessoa.Nome : null))

                .ForMember(dest => dest.QualificacaoId,
                    opt => opt.MapFrom(src => src.QualificacaoId))

                .ForMember(dest => dest.NomeQualificacao,
                    opt => opt.MapFrom(src =>
                        src.Qualificacao != null ? src.Qualificacao.NomeQualificacao : null));


            // =========================
            // ETIQUETAS
            // =========================
            CreateMap<GrupoEtiquetasProcessos, GrupoEtiquetaProcessoRequest>()
                .ForMember(dest => dest.EtiquetaId,
                    opt => opt.MapFrom(src => src.EtiquetaId));

            #endregion
            #endregion



            #region TAREFAS

            // =========================
            // CREATE
            // =========================
            CreateMap<CriarTarefaRequest, Tarefa>()
                .ForMember(dest => dest.ListasTarefa, opt => opt.Ignore())
                .ForMember(dest => dest.GrupoTarefasEtiquetas, opt => opt.Ignore())
                .ForMember(dest => dest.GrupoTarefaResponsaveis, opt => opt.Ignore());

            CreateMap<Tarefa, CriarTarefaResponse>();

            // =========================
            // LISTA TAREFA
            // =========================
            CreateMap<CriarListaTarefaRequest, ListaTarefa>();

            CreateMap<ListaTarefa, ListaTarefasResponse>()
                .ForMember(dest => dest.Descricao,
                    opt => opt.MapFrom(src => src.Descricao));


            // =========================
            // RESPONSE PRINCIPAL (OBTER TAREFA)
            // =========================
            CreateMap<Tarefa, ObterTarefaResponse>()

                // 🔹 BÁSICOS
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id))

                .ForMember(dest => dest.Descricao,
                    opt => opt.MapFrom(src => src.Descricao))

                .ForMember(dest => dest.DataTarefa,
                    opt => opt.MapFrom(src => src.DataTarefa))

                .ForMember(dest => dest.Prioridade,
                    opt => opt.MapFrom(src => src.Prioridade))

                .ForMember(dest => dest.StatusGeralKanban,
                    opt => opt.MapFrom(src => src.StatusGeralKanban))


                // =========================
                // 🔗 VÍNCULOS (CORRIGIDO)
                // =========================
                .ForMember(dest => dest.TipoVinculo,
                    opt => opt.MapFrom(src => src.TipoVinculo != null ? (int?)src.TipoVinculo : null))

                .ForMember(dest => dest.ProcessoId,
                    opt => opt.MapFrom(src => src.ProcessoId))

                .ForMember(dest => dest.CasoId,
                    opt => opt.MapFrom(src => src.CasoId))

                .ForMember(dest => dest.AtendimentoId,
                    opt => opt.MapFrom(src => src.AtendimentoId))


                // =========================
                // 🔥 DESCRIÇÕES DOS VÍNCULOS (SEGURAS)
                // =========================
                .ForMember(dest => dest.ProcessoPasta,
                    opt => opt.MapFrom(src => src.Processo != null ? src.Processo.Pasta : null))

                .ForMember(dest => dest.CasoPasta,
                    opt => opt.MapFrom(src => src.Caso != null ? src.Caso.Pasta : null))

                .ForMember(dest => dest.AtendimentoAssunto,
                    opt => opt.MapFrom(src => src.Atendimento != null ? src.Atendimento.Assunto : null))


                // =========================
                // 📋 LISTA
                // =========================
                .ForMember(dest => dest.ListasTarefa,
                    opt => opt.MapFrom(src => src.ListasTarefa))


                // =========================
                // 👥 RESPONSÁVEIS
                // =========================
                .ForMember(dest => dest.GrupoTarefaResponsaveis,
                    opt => opt.MapFrom(src => src.GrupoTarefaResponsaveis))


                // =========================
                // 🏷️ ETIQUETAS
                // =========================
                .ForMember(dest => dest.GrupoTarefasEtiquetas,
                    opt => opt.MapFrom(src => src.GrupoTarefasEtiquetas));


            // =========================
            // 👤 RESPONSÁVEIS (DETALHE)
            // =========================
            CreateMap<GrupoTarefaResponsaveis, TarefaResponsavelResponse>()
                .ForMember(d => d.UsuarioId,
                    o => o.MapFrom(s => s.UsuarioId))
                .ForMember(d => d.Nome,
                    o => o.MapFrom(s => s.Usuario != null ? s.Usuario.NomeUsuario : null));


            // =========================
            // 👤 RESPONSÁVEIS (SELECT ANGULAR)
            // =========================
            CreateMap<GrupoTarefaResponsaveis, ConsultarUsuarioResponse>()
                .ForMember(d => d.Id,
                    o => o.MapFrom(s => s.UsuarioId)) // 🔥 CORRIGIDO (era Usuario.Id)
                .ForMember(d => d.NomeUsuario,
                    o => o.MapFrom(s => s.Usuario != null ? s.Usuario.NomeUsuario : null));


            // =========================
            // 🏷️ ETIQUETAS
            // =========================
            CreateMap<GrupoTarefasEtiquetas, EtiquetaResponse>()
                .ForMember(d => d.Id,
                    o => o.MapFrom(s => s.EtiquetaId))
                .ForMember(d => d.Nome,
                    o => o.MapFrom(s => s.Etiqueta != null ? s.Etiqueta.Nome : null))
                .ForMember(d => d.Cor,
                    o => o.MapFrom(s => s.Etiqueta != null ? s.Etiqueta.Cor : null));

            #endregion
            #region Caso

            // =========================
            // CREATE (Cadastro)
            // =========================
            CreateMap<Caso, CriarCasoResponse>();
            CreateMap<CriarCasoRequest, Caso>()
                .ForMember(dest => dest.GrupoCasoClientes, opt => opt.Ignore())
                .ForMember(dest => dest.GrupoCasoEnvolvidos, opt => opt.Ignore())
                .ForMember(dest => dest.GrupoEtiquetaCasos, opt => opt.Ignore());

            // =========================
            // UPDATE (Edição)
            // =========================
            CreateMap<CasoUpdateRequest, Caso>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DataCadastro, opt => opt.Ignore())
                .ForMember(dest => dest.GrupoCasoClientes, opt => opt.Ignore())
                .ForMember(dest => dest.GrupoCasoEnvolvidos, opt => opt.Ignore())
                .ForMember(dest => dest.GrupoEtiquetaCasos, opt => opt.Ignore());

            // =========================
            // RESPONSE (CASO PRINCIPAL)
            // =========================
            CreateMap<Caso, ObterCasoResponse>()
                .ForMember(dest => dest.GrupoCasoClientes,
                    opt => opt.MapFrom(src => src.GrupoCasoClientes))

                .ForMember(dest => dest.GrupoCasoEnvolvidos,
                    opt => opt.MapFrom(src => src.GrupoCasoEnvolvidos))

                .ForMember(dest => dest.GrupoEtiquetaCaso,
                    opt => opt.MapFrom(src => src.GrupoEtiquetaCasos))

                .ForMember(dest => dest.ResponsavelNome,
                    opt => opt.MapFrom(src => src.Responsavel != null ? src.Responsavel.NomeUsuario : null))

                .ForMember(dest => dest.UsuarioCadastroNome,
                    opt => opt.MapFrom(src => src.UsuarioCadastro != null ? src.UsuarioCadastro.NomeUsuario : null));

            // =========================
            // CLIENTES DO CASO
            // =========================
            CreateMap<GrupoCasoCliente, GrupoCasoClienteResponse>()
                .ForMember(dest => dest.PessoaId,
                    opt => opt.MapFrom(src => src.PessoaId))

                .ForMember(dest => dest.CasoId,
                    opt => opt.MapFrom(src => src.CasoId))

                .ForMember(dest => dest.Nome,
                    opt => opt.MapFrom(src => src.Pessoa != null ? src.Pessoa.Nome : null));

            // =========================
            // ENVOLVIDOS DO CASO
            // =========================
            CreateMap<GrupoCasoEnvolvido, GrupoCasoEnvolvidosResponse>()
                .ForMember(dest => dest.PessoaId,
                    opt => opt.MapFrom(src => src.PessoaId))

                .ForMember(dest => dest.Nome,
                    opt => opt.MapFrom(src => src.Pessoa != null ? src.Pessoa.Nome : null))

                .ForMember(dest => dest.QualificacaoId,
                    opt => opt.MapFrom(src => src.QualificacaoId))

                .ForMember(dest => dest.NomeQualificacao,
                    opt => opt.MapFrom(src =>
                        src.Qualificacao != null ? src.Qualificacao.NomeQualificacao : null));

            // =========================
            // ETIQUETAS DO CASO
            // =========================
            CreateMap<GrupoEtiquetaCasos, GrupoEtiquetaCasoResponse>()
                .ForMember(dest => dest.EtiquetaId,
                    opt => opt.MapFrom(src => src.EtiquetaId))

                .ForMember(dest => dest.Nome,
                    opt => opt.MapFrom(src =>
                        src.Etiqueta != null ? src.Etiqueta.Nome : null))

                .ForMember(dest => dest.Cor,
                    opt => opt.MapFrom(src =>
                        src.Etiqueta != null ? src.Etiqueta.Cor : null));

            #endregion
            #region GrupoCasoCliente

            CreateMap<GrupoCasoClienteRequest, GrupoCasoCliente>();

            #endregion

            #region GrupoCasoEnvolvido

            CreateMap<GrupoCasoEnvolvidosRequest, GrupoCasoEnvolvido>();

            #endregion

            #region ATENDIMENTO

            // =============================
            // 🔹 REQUEST → ENTITY (CRIAR)
            // =============================
            CreateMap<CriarAtendimentoClienteRequest, Atendimento>()
          .ForMember(x => x.GrupoEtiquetasAtendimentos, opt => opt.Ignore())
          .ForMember(x => x.GrupoClientes, opt => opt.Ignore())
          .ForMember(x => x.Processo, opt => opt.Ignore())
          .ForMember(x => x.Caso, opt => opt.Ignore())
          .ForMember(x => x.AtendimentoPai, opt => opt.Ignore())
          .ForMember(x => x.Responsavel, opt => opt.Ignore());

            // =============================
            // 🔹 UPDATE → ENTITY
            // =============================
            CreateMap<AtendimentoClienteUpdateRequest, Atendimento>()
    .ForMember(x => x.GrupoEtiquetasAtendimentos, opt => opt.Ignore())
    .ForMember(x => x.GrupoClientes, opt => opt.Ignore())
    .ForMember(x => x.Processo, opt => opt.Ignore())
    .ForMember(x => x.Caso, opt => opt.Ignore())
    .ForMember(x => x.AtendimentoPai, opt => opt.Ignore())
    .ForMember(x => x.Responsavel, opt => opt.Ignore())
    .ForMember(x => x.DataCadastro, opt => opt.Ignore())
    .ForMember(x => x.ProcessoId, opt => opt.Ignore())
    .ForMember(x => x.CasoId, opt => opt.Ignore())
    .ForMember(x => x.AtendimentoPaiId, opt => opt.Ignore())
    .ForMember(x => x.ResponsavelId, opt => opt.Ignore());

            // =============================
            // 🔥 ENTITY → RESPONSE
            // =============================
            CreateMap<Atendimento, CriarAtendimentoClienteResponse>()
     .ForMember(d => d.GrupoAtendimentoCliente,
         o => o.MapFrom(s => s.GrupoClientes))

     .ForMember(d => d.GrupoAtendimentoEtiqueta,
         o => o.MapFrom(s => s.GrupoEtiquetasAtendimentos));
            CreateMap<GrupoAtendimentoCliente, GrupoAtendimentoClienteResponse>()
    .ForMember(d => d.Nome,
        o => o.MapFrom(s => s.Pessoa.Nome));
            CreateMap<GrupoEtiquetasAtendimentos, GrupoEtiquetaAtendimentoResponse>()
    .ForMember(d => d.EtiquetaId,
        o => o.MapFrom(s => s.EtiquetaId))
    .ForMember(d => d.Nome,
        o => o.MapFrom(s => s.Etiqueta.Nome))
    .ForMember(d => d.Cor,
        o => o.MapFrom(s => s.Etiqueta.Cor));
            CreateMap<Atendimento, ObterAtendimentoResponse>()
      // vínculos
      .ForMember(d => d.ProcessoPasta,
          opt => opt.MapFrom(s => s.Processo != null ? s.Processo.Pasta : null))

      .ForMember(d => d.CasoPasta,
          opt => opt.MapFrom(s => s.Caso != null ? s.Caso.Pasta : null))

      .ForMember(d => d.AtendimentoAssunto,
          opt => opt.MapFrom(s => s.AtendimentoPai != null ? s.AtendimentoPai.Assunto : null))

      // clientes
      .ForMember(d => d.GrupoAtendimentoCliente,
          opt => opt.MapFrom(s => s.GrupoClientes))

      // etiquetas
      .ForMember(d => d.GrupoAtendimentoEtiqueta,
          opt => opt.MapFrom(s => s.GrupoEtiquetasAtendimentos));
            CreateMap<GrupoAtendimentoCliente, GrupoAtendimentoClienteResponse>()
    .ForMember(d => d.PessoaId,
        opt => opt.MapFrom(s => s.PessoaId))
    .ForMember(d => d.Nome,
        opt => opt.MapFrom(s => s.Pessoa.Nome));

            CreateMap<GrupoEtiquetasAtendimentos, GrupoEtiquetaAtendimentoResponse>()
    .ForMember(d => d.EtiquetaId,
        opt => opt.MapFrom(s => s.EtiquetaId))
    .ForMember(d => d.Nome,
        opt => opt.MapFrom(s => s.Etiqueta != null ? s.Etiqueta.Nome : null))
    .ForMember(d => d.Cor,
        opt => opt.MapFrom(s => s.Etiqueta != null ? s.Etiqueta.Cor : null));

            #endregion


            #region Evento

            CreateMap<CriarEventoRequest, Evento>()
                .ForMember(dest => dest.GrupoEventoEtiquetas, opt => opt.Ignore())
                .ForMember(dest => dest.GrupoEventoResponsaveis, opt => opt.Ignore());



            CreateMap<UpdateEventoRequest, Evento>()
                .ForMember(dest => dest.GrupoEventoEtiquetas, opt => opt.Ignore())
                .ForMember(dest => dest.GrupoEventoResponsaveis, opt => opt.Ignore());
            CreateMap<Evento, CriarEventoResponse>()
          .ForCtorParam("Titulo",
              opt => opt.MapFrom(src => src.Titulo))
          .ForCtorParam("StatusGeralKanban",
              opt => opt.MapFrom(src => src.StatusGeralKanban
                  .ToString()
                  .Replace("_", " ")));
            CreateMap<Evento, ObterEventoResponse>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
               .ForMember(dest => dest.DataInicial, opt => opt.MapFrom(src => src.DataInicial))
               .ForMember(dest => dest.HoraInicial, opt => opt.MapFrom(src => src.HoraInicial))
               .ForMember(dest => dest.DataFinal, opt => opt.MapFrom(src => src.DataFinal))
               .ForMember(dest => dest.HoraFinal, opt => opt.MapFrom(src => src.HoraFinal))
               .ForMember(dest => dest.DiaInteiro, opt => opt.MapFrom(src => src.DiaInteiro))
               .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco))
               .ForMember(dest => dest.Modalidade, opt => opt.MapFrom(src => src.Modalidade))
               .ForMember(dest => dest.Observacao, opt => opt.MapFrom(src => src.Observacao))
               .ForMember(dest => dest.StatusGeralKanban, opt => opt.MapFrom(src => src.StatusGeralKanban))
               .ForMember(dest => dest.ProcessoId, opt => opt.MapFrom(src => src.ProcessoId))
               .ForMember(dest => dest.CasoId, opt => opt.MapFrom(src => src.CasoId))
               .ForMember(dest => dest.AtendimentoId, opt => opt.MapFrom(src => src.AtendimentoId))
               .ForMember(dest => dest.TipoVinculo, opt => opt.MapFrom(src => src.TipoVinculo))

               // 🔥 AQUI ESTÁ A CORREÇÃO
               .ForMember(dest => dest.ProcessoPasta,
                   opt => opt.MapFrom(src =>
                       src.Processo != null ? src.Processo.Pasta : null))

               .ForMember(dest => dest.CasoPasta,
                   opt => opt.MapFrom(src =>
                       src.Caso != null ? src.Caso.Pasta : null))

               .ForMember(dest => dest.AtendimentoAssunto,
                   opt => opt.MapFrom(src =>
                       src.Atendimento != null ? src.Atendimento.Assunto : null));

            CreateMap<GrupoEventoResponsavel, GrupoEventoResponsavelResponse>()
    .ForMember(dest => dest.UsuarioId,
        opt => opt.MapFrom(src => src.UsuarioId))
    .ForMember(dest => dest.NomeUsuario,
        opt => opt.MapFrom(src => src.Usuario.NomeUsuario));

            CreateMap<GrupoEventoEtiquetas, GrupoEventoEtiquetasResponse>()
                .ForMember(dest => dest.EtiquetaId,
                    opt => opt.MapFrom(src => src.EtiquetaId))
                .ForMember(dest => dest.Nome,
                    opt => opt.MapFrom(src => src.Etiqueta.Nome))
                .ForMember(dest => dest.Cor,
                    opt => opt.MapFrom(src => src.Etiqueta.Cor));
            #endregion
            #region GrupoEvento

            CreateMap<GrupoEventoResponsavel, GrupoEventoResponsavel>();

            #endregion
            #region Agenda
            CreateMap<Tarefa, AgendaItemResponse>()
    .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Descricao))
    .ForMember(dest => dest.Data, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.DataTarefa ?? src.DataCadastro)))
    .ForMember(dest => dest.Tipo, opt => opt.MapFrom(_ => "Tarefa"))
    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (StatusGeralKanban)src.StatusGeralKanban))
    .ForMember(dest => dest.HoraInicio, opt => opt.Ignore())
    .ForMember(dest => dest.HoraFim, opt => opt.Ignore());

            CreateMap<Evento, AgendaItemResponse>()
    .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
    .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.DataInicial))
    .ForMember(dest => dest.HoraInicio, opt => opt.MapFrom(src => src.HoraInicial))
    .ForMember(dest => dest.HoraFim, opt => opt.MapFrom(src => src.HoraFinal))
    .ForMember(dest => dest.Tipo, opt => opt.MapFrom(_ => "Evento"))
    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (StatusGeralKanban)src.StatusGeralKanban));
            #endregion
            #region etiquetas
            CreateMap<Etiqueta, EtiquetaResponse>();



            #endregion
            #region Conta bancaria
            CreateMap<ContaBancariaRequest, ContaBancaria>()
     .ForMember(dest => dest.TipoConta, opt => opt.MapFrom(src => src.TipoConta));
            #endregion
            #region Pesoas Etiquetas
            CreateMap<GrupoPessoasEtiquetas, GrupoPessoasEtiquetasResponse>()
    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EtiquetaId))
    .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Etiqueta.Nome))
    .ForMember(dest => dest.Cor, opt => opt.MapFrom(src => src.Etiqueta.Cor));
            #endregion
            #region vara
            CreateMap<Vara, VaraResponse>()
         .ForMember(dest => dest.NomeForo,
             opt => opt.MapFrom(src => src.Foro.NomeForo));
            #endregion
            #region Acao
            CreateMap<Acao, AcaoResponse>()
     .ForCtorParam("IdAcao", opt => opt.MapFrom(src => src.Id))
     .ForCtorParam("NomeAcao", opt => opt.MapFrom(src => src.NomeAcao));
            #endregion
            #region Qualificacao
            CreateMap<Qualificacao, QualificacaoResponse>()
     .ForCtorParam("IdQualificacao", opt => opt.MapFrom(src => src.Id))
     .ForCtorParam("NomeQualificacao", opt => opt.MapFrom(src => src.NomeQualificacao));
            #endregion
            #region comentario


            CreateMap<CriarComentarioRequest, Comentario>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.UsuarioId, opt => opt.Ignore())
            .ForMember(dest => dest.DataCriacao, opt => opt.MapFrom(_ => DateTime.Now))
            .ForMember(dest => dest.Texto, opt => opt.MapFrom(src => src.Texto.Trim()));


            #endregion
        }
    }
}