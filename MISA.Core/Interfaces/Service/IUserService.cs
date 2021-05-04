using SharedModel.Request;

namespace MISA.Core.Interfaces
{
    public interface IUserService
    {
        public string Authentication(UserLoginRequest request);
    }
}