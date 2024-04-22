using OptiStock.MAUI.Models;

namespace OptiStock.MAUI.State.Accounts
{
    public interface IAccountStore
    {
        AccountModel CurrentAccount { get; set; }
    }
}
