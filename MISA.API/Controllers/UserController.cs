using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interfaces;
using SharedModel.Request;

namespace MISA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

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