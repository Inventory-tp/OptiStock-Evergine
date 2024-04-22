using OptiStock.MAUI.Models;
using OptiStock.MAUI.Services.Common;

namespace OptiStock.MAUI.Services
{
    public interface IAccountRepository : IDataRepository<AccountModel>
    {
        Task<Result<AccountModel>> GetByUsername(string username);
        Task<Result<AccountModel>> GetByEmail(string email);
    }
}
