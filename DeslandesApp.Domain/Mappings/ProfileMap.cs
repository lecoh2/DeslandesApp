using AutoMapper;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoNiveis;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoSetores;
using DeslandesApp.Domain.Models.Dtos.Requests.InformacoesComplementares;
using DeslandesApp.Domain.Models.Dtos.Requests.Nivel;
using DeslandesApp.Domain.Models.Dtos.Requests.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Requests.Setor;
using DeslandesApp.Domain.Models.Dtos.Requests.Usuarios;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoNiveis;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoSetores;
using DeslandesApp.Domain.Models.Dtos.Responses.Nivel;
using DeslandesApp.Domain.Models.Dtos.Responses.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Responses.Setor;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Mappings
{
    public class ProfileMap : Profile
    {       
            public ProfileMap()
            {
            #region Usuarios

            CreateMap<UsuariosRequest, Usuario>()
                .ForMember(dest => dest.ValorEmail,
                    opt => opt.MapFrom(src => new ValorEmail(src.Email)));

            CreateMap<UsuarioUpdateRequest, Usuario>()
    .ForMember(dest => dest.ValorEmail,
        opt => opt.MapFrom(src =>
            string.IsNullOrEmpty(src.Email)
            ? null
            : new ValorEmail(src.Email)
        ));

            CreateMap<Usuario, UsuariosResponse>()
                .ForCtorParam(
                    "Email",
                    opt => opt.MapFrom(src => src.ValorEmail.EnderecoEmail)
                );

            #endregion




            #region Setor
            CreateMap<SetorRequest, Setor>();

                CreateMap<Setor, SetorResponse>()
                    .ForCtorParam("IdSetor", opt => opt.MapFrom(src => src.Id))
                    .ForCtorParam("NomeSetor", opt => opt.MapFrom(src => src.NomeSetor));
                #endregion


                #region Nivel
                CreateMap<NivelRequest, Niveis>();

                CreateMap<Niveis, NivelResponse>()
                    .ForCtorParam("IdNivel", opt => opt.MapFrom(src => src.Id))
                    .ForCtorParam("NomeNivel", opt => opt.MapFrom(src => src.NomeNivel));


            #endregion
            #region GrupoNivel
            CreateMap<GrupoNivelRequest, GrupoNiveis>();
            CreateMap<GrupoNiveis, GrupoNivelResponse>();
            #endregion
            #region GrupoSetores
            CreateMap<GrupoSetorRequest, GrupoSetores>();
            CreateMap<GrupoSetores, GrupoSetorResponse>();
            #endregion
            #region PessoaFiscica
            CreateMap<PessoaFisicaRequest, PessoaFisica>()
    .ForMember(dest => dest.ValorEmail,
        opt => opt.MapFrom(src =>
            string.IsNullOrEmpty(src.Email)
            ? null
            : new ValorEmail(src.Email)
        ));
            CreateMap<PessoaFisica, PessoaFisicaResponse>()
    .ForCtorParam(
        "Email",
        opt => opt.MapFrom(src => src.ValorEmail.EnderecoEmail)
    );
            #endregion
            #region Informacoes Complementares
            CreateMap<InformacoesComplementaresRequest, InformacoesComplementares>();
            #endregion
        }
    }

    }

