using OptiStock.MAUI.Models;
using OptiStock.MAUI.Services.Authentication;
using OptiStock.MAUI.Services.Common;
using OptiStock.MAUI.State.Accounts;

namespace OptiStock.MAUI.State.Authenticators
{
    //Authentication Class management
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IAccountStore _accountStore;

        //Class constructor with IAuthenticationRepository class as parameter
        public Authenticator(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public AccountModel CurrentAccount { get
            {
                return _accountStore.CurrentAccount;
            }
            private set
            {
                _accountStore.CurrentAccount = value;
                StateChanged?.Invoke();
            }
        }


        public bool IsLoggedIn => CurrentAccount != null;

        public event Action StateChanged;

        public Authenticator(IAccountStore accountStore)
        {
            _accountStore = accountStore;
        }

        public async Task<Result<AccountModel>> Login(string username, string password)
        {
            try
            {
                Result<AccountModel> _account = await _authenticationRepository.Login(username, password);

                Result<AccountModel>.Match(
                _account,
                onSuccess: (entity) => entity = CurrentAccount, //Set the Accountmodel value result of login to the CurrentAccount
                onFailure: (error) => throw error);

                return _account;
            }
            catch (Exception ex)
            {
                return Result<AccountModel>.Failure(ex);
            }
        }

        public void Logout()
        {
            CurrentAccount = null; //Set current Account to null in case of Logout
        }

        public async Task<Result<bool>> Register(string email, string username, string password, string confirmPassword, UsersRights rights)
        {
            return await _authenticationRepository.Register(email, username, password, confirmPassword, rights);
        }
    }
}
