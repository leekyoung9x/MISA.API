using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MISA.Core.Interfaces;
using SharedModel.Request;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MISA.Core.Services
{
    /// <summary>
    /// Class thể hiện các dịch vụ cho bảng User
    /// </summary>
    /// CreatedDate: 5/4/2021
    /// CreateBy: THTùng
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="config">Search GG để biết thêm về IConfiguration</param>
        public UserService(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Hàm đăng nhập
        /// </summary>
        /// <param name="request">Thông tin đăng nhập</param>
        /// <returns>Chuỗi token nếu đăng nhập hợp lệ, ngược lại thì null</returns>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùngCreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public string Authentication(UserLoginRequest request)
        {
            //var user = await _userManager.FindByNameAsync(request.UserName);
            //if (user == null) return new ApiErrorResult<string>("Tài khoản không tồn tại");

            //var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            //if (!result.Succeeded)
            //{
            //    return new ApiErrorResult<string>("Đăng nhập không đúng");
            //}
            //var roles = await _userManager.GetRolesAsync(user);
            if (request.Username != "sanggia5512" || request.Password != "Aa123!@#")
            {
                return null;
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.GivenName,request.Username),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddSeconds(60),
                signingCredentials: creds);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}