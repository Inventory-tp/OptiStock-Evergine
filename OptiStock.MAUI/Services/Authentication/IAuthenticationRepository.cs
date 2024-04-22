using OptiStock.MAUI.Models;
using OptiStock.MAUI.Services.Common;


namespace OptiStock.MAUI.Services.Authentication
{
    public interface IAuthenticationRepository
    {
        Task<Result<bool>> Register(string email, string username, string password, string confirmPassword, UsersRights rights);
        Task<Result<AccountModel>> Login(string username, string password);
    }
}
