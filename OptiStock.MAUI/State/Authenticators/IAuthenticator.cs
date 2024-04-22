using OptiStock.MAUI.Models;
using OptiStock.MAUI.Services.Common;

namespace OptiStock.MAUI.State.Authenticators
{
    public interface IAuthenticator
    {
        AccountModel CurrentAccount { get; }
        bool IsLoggedIn { get; }
        event Action StateChanged;
        Task<Result<bool>> Register(string email, string username, string password, string confirmPassword, UsersRights rights);
        Task<Result<AccountModel>> Login(string username, string password);
        void Logout();
    }
}
