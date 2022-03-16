using AutoMapper;
using Catalog.Menus.Domains;
using Catalog.Repositories.Menus.Entities;

namespace Catalog.Repositories.Menus.Profiles
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<MenuEntity, Menu>();
        }
    }
}