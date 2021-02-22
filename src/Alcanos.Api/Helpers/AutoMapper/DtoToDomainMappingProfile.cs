using Alcanos.Api.Dtos;
using Alcanos.Domain.Models;
using AutoMapper;

namespace Alcanos.Api.Helpers.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<OpcionDto, Opcion>();
            CreateMap<RolDto,Rol>();
            CreateMap<RolOpcionDto, RolOpcion>();
            CreateMap<UsuarioDto,Usuario>();
            CreateMap<UsuarioRolDto, UsuarioRol>();
        }
    }
}
