using Catalog.Menus.Contracts;
using Catalog.Menus.Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers.Menus
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        #region Properties

        private readonly IMenusService _service;
        private readonly AbstractValidator<AddMenuDto> _addMenueValidator;
        private readonly AbstractValidator<UpdateMenuDto> _updateMenueValidator;

        #endregion Properties

        #region Constructor

        public MenusController(IMenusService service, AbstractValidator<AddMenuDto> addMenueValidator, AbstractValidator<UpdateMenuDto> updateMenueValidator)
        {
            _service = service;
            _addMenueValidator = addMenueValidator;
            _updateMenueValidator = updateMenueValidator;
        }

        #endregion Constructor

        #region Methods

        [HttpGet("all")]
        [Produces(typeof(IEnumerable<MenuDto>))]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _service.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(MenuDto))]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            try
            {
                var result = await _service.GetAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddMenuDto dto)
        {
            try
            {
                var result = _addMenueValidator.Validate(dto);
                if (!result.IsValid)
                {
                    return BadRequest(result.Errors);
                }

                await _service.AddAsync(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateMenuDto dto)
        {
            try
            {
                var result = _updateMenueValidator.Validate(dto);
                if (!result.IsValid)
                {
                    return BadRequest(result.Errors);
                }

                await _service.UpdateAsync(id, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            try
            {
                await _service.RemoveAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        #endregion Methods
    }
}