using AutoMapper;
using EL.Entity;

namespace EL.Application
{
    public class AutoMapperConfigs : Profile
    {
        public AutoMapperConfigs()
        {
            CreateMap<MenuEntity, MenuTreeDto>();
        }
    }
}
