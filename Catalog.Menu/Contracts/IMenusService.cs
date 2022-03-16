using Catalog.Menus.Dtos;

namespace Catalog.Menus.Contracts
{
    public interface IMenusService
    {
        Task<IEnumerable<MenuDto>> GetAllAsync();

        Task<MenuDto> GetAsync(Guid id);

        Task AddAsync(AddMenuDto dto);

        Task UpdateAsync(Guid id, UpdateMenuDto dto);

        Task RemoveAsync(Guid id);
    }
}