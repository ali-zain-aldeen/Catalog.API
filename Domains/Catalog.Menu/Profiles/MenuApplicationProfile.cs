using AutoMapper;
using Catalog.Menus.Domains;
using Catalog.Menus.Dtos;

namespace Catalog.Menus.Profiles
{
    public class MenuApplicationProfile : Profile
    {
        public MenuApplicationProfile()
        {
            CreateMap<Menu, MenuDto>();
            CreateMap<AddMenuDto, Menu>();
        }
    }
}