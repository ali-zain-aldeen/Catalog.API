using Catalog.Menus.Domains;

namespace Catalog.Menus.Contracts
{
    public interface IMenusRepository
    {
        Task<IEnumerable<Menu>> GetAllAsync();

        Task<Menu> GetAsync(Guid id);

        Task AddAsync(Menu menu);

        Task UpdateAsync(Menu menu);

        Task RemoveAsync(Guid id);
    }
}