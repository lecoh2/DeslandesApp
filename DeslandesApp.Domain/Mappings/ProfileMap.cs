using AutoMapper;
using DeslandesApp.Domain.Models.Dtos.Requests.Nivel;
using DeslandesApp.Domain.Models.Dtos.Requests.Setor;
using DeslandesApp.Domain.Models.Dtos.Requests.Usuarios;
using DeslandesApp.Domain.Models.Dtos.Responses.Nivel;
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
            // Request → Entity
            CreateMap<UsuariosRequest, Usuario>()
                .ForMember(dest => dest.ValorEmail,
                    opt => opt.MapFrom(src => new ValorEmail(src.Email)));

            // Entity → Response
            CreateMap<Usuario, UsuariosResponse>()
                .ForMember(dest => dest.Email,
                    opt => opt.MapFrom(src => src.ValorEmail.EnderecoEmail));
            #endregion
            #region Setor
            // Request → Entity
            CreateMap<SetorRequest, Setor>();
            // Entity → Response
            CreateMap<Setor, SetorResponse>();
            #endregion
            #region Nivel
            // Request → Entity
            CreateMap<NivelRequest, Niveis>();
            // Entity → Response
            CreateMap<Niveis, NivelResponse>();
            #endregion
        }
    }
}
