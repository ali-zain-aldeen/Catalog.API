using Catalog.Menus.Contracts;
using Catalog.Menus.Dtos;

namespace Catalog.Menus.Services
{
    public class MenusService : IMenusService
    {
        #region Properties

        private readonly IMenusRepository _menusRepository;

        #endregion

        #region Constructor

        public MenusService(IMenusRepository menusRepository)
        {
            _menusRepository = menusRepository;
        }

        #endregion

        #region Methods

        public Task AddAsync(AddMenuDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MenuDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MenuDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, UpdateMenuDto dto)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
