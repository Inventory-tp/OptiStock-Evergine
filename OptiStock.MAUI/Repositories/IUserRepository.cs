using OptiStock.MAUI.Models;

namespace OptiStock.MAUI.Repositories
{
    public interface IUserRepository
    {
        Task<int> Add(UserModel user);
        Task<int> Update(UserModel user);
        Task<List<UserModel>> getList();
        Task<int> Delete(UserModel user);
    }
}
