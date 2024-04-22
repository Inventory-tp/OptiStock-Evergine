using OptiStock.MAUI.Models;

namespace OptiStock.MAUI.State.Accounts
{
    public class AccountStore : IAccountStore
    {
        public AccountModel CurrentAccount { get; set; }
    }
}
