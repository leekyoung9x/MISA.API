using SharedModel.Request;

namespace MISA.Core.Interfaces
{
    /// <summary>
    /// Interface thể hiện các dịch vụ cho bảng tài khoản
    /// </summary>
    /// CreatedDate: 5/4/2021
    /// CreateBy: THTùng
    public interface IUserService
    {
        /// <summary>
        /// Hàm kiểm tra tài khoản có trong db hay không
        /// </summary>
        /// <param name="request">Thông tin tài khoản người dùng nhập vào</param>
        /// <returns>Trả về token cho user đăng nhập</returns>
        /// CreatedDate: 5/4/2021
        /// CreateBy: THTùng
        public string Authentication(UserLoginRequest request);
    }
}