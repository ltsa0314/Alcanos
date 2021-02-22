using Alcanos.Api.Dtos;
using Alcanos.Domain.Models;
using AutoMapper;

namespace Alcanos.Api.Helpers.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Opcion, OpcionDto>();
            CreateMap<Rol, RolDto>();
            CreateMap<RolOpcion, RolOpcionDto>();
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioRol, UsuarioRolDto>();
            
        }
    }
}
