using AutoMapper;
using Catalog.Common.Models;
using Catalog.Menus.Contracts;
using Catalog.Menus.Domains;
using Catalog.Menus.Dtos;
using MassTransit;

namespace Catalog.Menus.Services
{
    public class MenusService : IMenusService
    {
        #region Properties

        private readonly IMenusRepository _menusRepository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        #endregion Properties

        #region Constructor

        public MenusService(IMenusRepository menusRepository, IMapper mapper, IBus bus)
        {
            _menusRepository = menusRepository;
            _mapper = mapper;
            _bus = bus;
        }

        #endregion Constructor

        #region Methods

        public async Task AddAsync(AddMenuDto dto)
        {
            try
            {
                var model = _mapper.Map<Menu>(dto);
                model.Id = Guid.NewGuid();

                await _menusRepository.AddAsync(model);


                //Sending Emails
                var email = new EmailMessage
                {
                    MenuName = dto.Name,
                    ToEmail = "alizainaldeen17@gmail.com",
                    ToName = "ali"
                };

                Uri uri = new Uri("rabbitmq://localhost/emailsQueue");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(email);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<MenuDto>> GetAllAsync()
        {
            try
            {

                var result = await _menusRepository.GetAllAsync();

                return _mapper.Map<IEnumerable<MenuDto>>(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MenuDto> GetAsync(Guid id)
        {
            try
            {
                var result = await _menusRepository.GetAsync(id);

                return _mapper.Map<MenuDto>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task RemoveAsync(Guid id)
        {
            try
            {

                await _menusRepository.RemoveAsync(id);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(Guid id, UpdateMenuDto dto)
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }

        #endregion Methods
    }
}