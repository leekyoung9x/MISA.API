using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interfaces;
using SharedModel.Request;

namespace MISA.API.Controllers
{
    /// <summary>
    /// API Controller for class User
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="userService"></param>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Phương thức đăng nhập
        /// </summary>
        /// <param name="request">Thông tin đăng nhập</param>
        /// <returns>Trả về token</returns>
        /// <response code="200">Trả về token nếu đăng nhập thành công!</response>
        /// <response code="204">Đăng nhập thất bại!</response>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        [HttpPost("authentication")]
        public IActionResult Authenticate([FromBody] UserLoginRequest request)
        {
            var result = _userService.Authentication(request);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, "Sai tài khoản hoặc mật khẩu!");
            }
        }
    }
}