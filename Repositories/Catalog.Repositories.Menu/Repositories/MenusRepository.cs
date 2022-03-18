using AutoMapper;
using Catalog.Menus.Contracts;
using Catalog.Menus.Domains;
using Catalog.Repositories.Menus.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Repositories.Menus.Repositories
{
    public class MenusRepository : IMenusRepository
    {
        #region Properties

        protected MenusDbContext _context;
        protected IMapper _mapper;

        #endregion Properties

        #region Constructor

        public MenusRepository(MenusDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        public async Task<IEnumerable<Menu>> GetAllAsync()
        {
            var result = await _context.Menues.ToListAsync();
            return _mapper.Map<IEnumerable<Menu>>(result);
        }

        public async Task<Menu> GetAsync(Guid id)
        {
            var result = await _context.Menues.FindAsync(id);
            return _mapper.Map<Menu>(result);
        }

        public async Task AddAsync(Menu menu)
        {
            var entity = _mapper.Map<MenuEntity>(menu);
            await _context.Menues.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var result = await _context.Menues.FindAsync(id);
            _context.Menues.Remove(result);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Menu menu)
        {
            var result = await _context.Menues.FindAsync(menu.Id);

            result.Name = menu.Name;
            result.Price = menu.Price;
            result.Cost = menu.Cost;
            result.Image = menu.Image;

            await _context.SaveChangesAsync();
        }

        #endregion Methods
    }
}