using AutoMapper;
using DeslandesApp.Domain.Models.Dtos.Requests.Usuarios;
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
            // Request → Entity
            CreateMap<UsuariosRequest, Usuario>()
                .ForMember(dest => dest.ValorEmail,
                    opt => opt.MapFrom(src => new ValorEmail(src.Email)));

            // Entity → Response
            CreateMap<Usuario, UsuariosResponse>()
                .ForMember(dest => dest.Email,
                    opt => opt.MapFrom(src => src.ValorEmail.EnderecoEmail));
        }
    }
}
