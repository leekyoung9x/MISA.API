using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace MISA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : class
    {
        private IGenericService<T> _baseService;

        private string tableName = typeof(T).Name;

        public BaseController(IGenericService<T> baseService)
        {
            _baseService = baseService;
        }

        /// <summary>
        /// Lấy danh sách thực thể
        /// </summary>
        /// <returns>Danh sách thực thể</returns>
        /// <response code="200">Trả về danh sách thực thể</response>
        /// <response code="204">Nếu danh sách thực thể trống</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _baseService.GetAllAsync();
            if (entities.Count > 0)
            {
                return Ok(entities);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Lấy ra 1 thực thể theo Id thực thể
        /// </summary>
        /// <param name="id">Nhập vào EntityId</param>
        /// <returns>thực thể</returns>
        /// <response code="200">Trả về thực thể</response>
        /// <response code="404">Không tìm thấy thực thể mang id truyền vào</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var entity = await _baseService.GetByIdAsync(id);
            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Lấy ra 1 thực thể theo mã thực thể
        /// </summary>
        /// <param name="code">Nhập vào mã thực thể</param>
        /// <returns>thực thể</returns>
        /// <response code="200">Trả về thực thể</response>
        /// <response code="404">Không tìm thấy thực thể mang id truyền vào</response>
        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var entity = await _baseService.GetByCodeAsync(code);
            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Thêm mới thực thể
        /// </summary>
        /// <param name="entity">Nhập thông tin thực thể</param>
        /// <returns>thực thể vừa được thêm</returns>
        /// <response code="201">Trả về thực thể vừa được thêm</response>
        /// <response code="204">Thêm thất bại</response>
        [HttpPost]
        public async Task<IActionResult> Post(T entity)
        {
            var result = await _baseService.AddAsync(entity);
            if (result > 0)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Sửa thực thể
        /// </summary>
        /// <param name="id">Nhập vào id thực thể</param>
        /// <param name="entity">Nhập vào thông tin thực thể</param>
        /// <returns></returns>
        /// <response code="200">Sửa thành công</response>
        /// <response code="204">Sửa thất bại</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, T entity)
        {
            var propertyId = typeof(T).GetProperty($"{tableName}Id");
            propertyId.SetValue(entity, Guid.Parse(id));
            var result = await _baseService.UpdateAsync(entity);
            if (result > 0)
            {
                return Ok();
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Xóa thực thể theo id
        /// </summary>
        /// <param name="id">Nhập vào EntityId</param>
        /// <returns></returns>
        /// <response code="200">Xóa thành công</response>
        /// <response code="204">Xóa thất bại</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _baseService.DeleteAsync(id);
            if (result > 0)
            {
                return Ok();
            }
            else
            {
                return NoContent();
            }
        }
    }
}