using Catalog.Menus.Contracts;
using Catalog.Menus.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers.Menus
{
    [Route("api/menues")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        #region Properties

        private readonly IMenusService _service;

        #endregion

        #region Constructor

        public MenusController(IMenusService service)
        {
            _service = service;
        }

        #endregion

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


        #endregion
    }
}