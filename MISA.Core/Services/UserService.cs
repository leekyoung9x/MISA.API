using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MISA.Core.Interfaces;
using SharedModel.Request;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;

        public UserService(IConfiguration config)
        {
            _config = config;
        }

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