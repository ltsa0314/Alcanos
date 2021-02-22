using System;

namespace Alcanos.Api.Helpers.AutoMapper
{
    public class AutoMapperConfig
    {

        public static Type[] RegisterMappings()
        {
            return new Type[]
            {
                typeof(DomainToDtoMappingProfile),
                typeof(DtoToDomainMappingProfile)
            };
        }
    }
}
