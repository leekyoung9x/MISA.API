using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace MISA.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// <response code="200">Trả về danh sách khách hàng</response>
        /// <response code="204">Nếu danh sách khách hàng trống</response>
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllAsync();
            if (customers.Count > 0)
            {
                return Ok(customers);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Lấy ra 1 khách hàng theo Id khách hàng
        /// </summary>
        /// <param name="id">Nhập vào CustomerId</param>
        /// <returns>Khách hàng</returns>
        /// <response code="200">Trả về khách hàng</response>
        /// <response code="404">Không tìm thấy khách hàng mang id truyền vào</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Lấy ra 1 khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="code">Nhập vào mã khách hàng</param>
        /// <returns>Khách hàng</returns>
        /// <response code="200">Trả về khách hàng</response>
        /// <response code="404">Không tìm thấy khách hàng mang id truyền vào</response>
        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var customer = await _customerService.GetByCodeAsync(code);
            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Nhập thông tin khách hàng</param>
        /// <returns>Khách hàng vừa được thêm</returns>
        /// <response code="201">Trả về khách hàng vừa được thêm</response>
        /// <response code="204">Thêm thất bại</response>
        [HttpPost]
        public async Task<IActionResult> Post(Customer customer)
        {
            var result = await _customerService.AddAsync(customer);
            if (result > 0)
            {
                return CreatedAtAction(nameof(GetByCode), new { code = customer.CustomerCode }, await _customerService.GetByCodeAsync(customer.CustomerCode.ToString()));
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Sửa khách hàng
        /// </summary>
        /// <param name="id">Nhập vào id khách hàng</param>
        /// <param name="customer">Nhập vào thông tin khách hàng</param>
        /// <returns></returns>
        /// <response code="200">Sửa thành công</response>
        /// <response code="204">Sửa thất bại</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Customer customer)
        {
            customer.CustomerId = Guid.Parse(id);
            var result = await _customerService.UpdateAsync(customer);
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
        /// Xóa khách hàng theo id
        /// </summary>
        /// <param name="id">Nhập vào CustomerId</param>
        /// <returns></returns>
        /// <response code="200">Xóa thành công</response>
        /// <response code="204">Xóa thất bại</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _customerService.DeleteAsync(id);
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