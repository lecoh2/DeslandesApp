using AutoMapper;
using DeslandesApp.Domain.Models.Dtos.Requests.EnderecoPessoa;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoNiveis;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoSetores;
using DeslandesApp.Domain.Models.Dtos.Requests.InformacoesComplementares;
using DeslandesApp.Domain.Models.Dtos.Requests.Nivel;
using DeslandesApp.Domain.Models.Dtos.Requests.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Requests.Processo;
using DeslandesApp.Domain.Models.Dtos.Requests.Setor;
using DeslandesApp.Domain.Models.Dtos.Requests.Tarefa;
using DeslandesApp.Domain.Models.Dtos.Requests.Usuarios;
using DeslandesApp.Domain.Models.Dtos.Responses.EnderecoEndereco;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoNiveis;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoSetores;
using DeslandesApp.Domain.Models.Dtos.Responses.InformacoesComplementares;
using DeslandesApp.Domain.Models.Dtos.Responses.Nivel;
using DeslandesApp.Domain.Models.Dtos.Responses.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Responses.Processo;
using DeslandesApp.Domain.Models.Dtos.Responses.Setor;
using DeslandesApp.Domain.Models.Dtos.Responses.Tarefa;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.ValueObjects;

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
                            : new ValorEmail(src.Email)))
                .ForMember(dest => dest.InformacoesComplementares, opt => opt.Ignore());

            CreateMap<PessoaJuridicaUpdateRequest, PessoaJuridica>()
                .ForMember(dest => dest.ValorEmail,
                    opt => opt.MapFrom(src =>
                        string.IsNullOrEmpty(src.Email)
                            ? null
                            : new ValorEmail(src.Email)))
                .ForMember(dest => dest.InformacoesComplementares, opt => opt.Ignore())
                .ForMember(dest => dest.Endereco, opt => opt.Ignore());

            CreateMap<PessoaJuridica, PessoaJuridicaResponse>()
                .ForCtorParam("Email",
                    opt => opt.MapFrom(src =>
                        src.ValorEmail != null
                            ? src.ValorEmail.EnderecoEmail
                            : null));

            #endregion


            #region PESSOA FISICA

            CreateMap<PessoaFisicaRequest, PessoaFisica>()
                .ForMember(dest => dest.ValorEmail,
                    opt => opt.MapFrom(src =>
                        string.IsNullOrEmpty(src.Email)
                            ? null
                            : new ValorEmail(src.Email)))
                .ForMember(dest => dest.InformacoesComplementares, opt => opt.Ignore());

            CreateMap<PessoaFisicaUpdateRequest, PessoaFisica>()
                .ForMember(dest => dest.InformacoesComplementares, opt => opt.Ignore())
                .ForMember(dest => dest.Endereco, opt => opt.Ignore());

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
            CreateMap<ProcessoRequest, Processo>()
      .ForMember(dest => dest.Vara, opt => opt.Ignore())
      .ForMember(dest => dest.UsuarioResponsavel, opt => opt.Ignore())
      .ForMember(dest => dest.Acao, opt => opt.Ignore())
      .ForMember(dest => dest.GrupoPessoaClientes, opt => opt.Ignore())
      .ForMember(dest => dest.GrupoEnvolvidos, opt => opt.Ignore());
            CreateMap<Processo, ProcessoResponse>()
     .ForCtorParam("Pasta", opt => opt.MapFrom(src => src.Pasta))
     .ForCtorParam("Titulo", opt => opt.MapFrom(src => src.Titulo))
     .ForCtorParam("NumeroProcesso", opt => opt.MapFrom(src => src.NumeroProcesso))
     .ForAllMembers(opt => opt.Ignore());
            #endregion
            #region Tarefas
            #region Tarefas

            CreateMap<CriarTarefaRequest, Tarefa>()
                .ForMember(dest => dest.ListasTarefa, opt => opt.Ignore());

            CreateMap<Tarefa, CriarTarefaResponse>();

            CreateMap<CriarListaTarefaRequest, ListaTarefa>()
                .ForMember(dest => dest.GrupoTarefaEnvolvido, opt => opt.Ignore());

            #endregion
            #endregion

        }
    }
}