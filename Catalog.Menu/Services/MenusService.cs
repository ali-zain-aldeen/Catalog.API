using AutoMapper;
using Catalog.Menus.Contracts;
using Catalog.Menus.Domains;
using Catalog.Menus.Dtos;

namespace Catalog.Menus.Services
{
    public class MenusService : IMenusService
    {
        #region Properties

        private readonly IMenusRepository _menusRepository;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructor

        public MenusService(IMenusRepository menusRepository, IMapper mapper)
        {
            _menusRepository = menusRepository;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        public async Task AddAsync(AddMenuDto dto)
        {
            var model = _mapper.Map<Menu>(dto);
            model.Id = Guid.NewGuid();

            await _menusRepository.AddAsync(model);
        }

        public async Task<IEnumerable<MenuDto>> GetAllAsync()
        {
            var result = await _menusRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<MenuDto>>(result);
        }

        public async Task<MenuDto> GetAsync(Guid id)
        {
            var result = await _menusRepository.GetAsync(id);

            return _mapper.Map<MenuDto>(result);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _menusRepository.RemoveAsync(id);
        }

        public async Task UpdateAsync(Guid id, UpdateMenuDto dto)
        {
            var model = await _menusRepository.GetAsync(id);

            if (dto.Price.HasValue)
            {
                model.Price = dto.Price.Value;
            }

            if (dto.Cost.HasValue)
            {
                model.Cost = dto.Cost.Value;
            }

            if (!string.IsNullOrEmpty(dto.Name))
            {
                model.Name = dto.Name;
            }

            if (!string.IsNullOrEmpty(dto.Image))
            {
                model.Image = dto.Image;
            }

            await _menusRepository.UpdateAsync(model);
        }

        #endregion Methods
    }
}