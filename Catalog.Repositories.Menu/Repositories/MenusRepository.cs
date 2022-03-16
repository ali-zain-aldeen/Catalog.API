using Catalog.Menus.Contracts;
using Catalog.Menus.Domains;

namespace Catalog.Repositories.Menus.Repositories
{
    public class MenusRepository : IMenusRepository
    {
        #region Methods

        public Task<IEnumerable<Menu>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Menu> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Menu menu)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Menu menu)
        {
            throw new NotImplementedException();
        }

        #endregion Methods
    }
}