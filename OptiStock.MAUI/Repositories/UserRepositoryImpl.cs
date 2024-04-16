using OptiStock.MAUI.Models;
using SQLite;

namespace OptiStock.MAUI.Repositories
{
    public class UserRepositoryImpl : IUserRepository
    {
        private SQLiteAsyncConnection _dataBase;
        public UserRepositoryImpl() {
            SetupDatabase();
        }

        public Task<int> Add(UserModel user) => _dataBase.InsertAsync(user);

        public Task<int> Delete(UserModel user) => _dataBase.DeleteAsync(user);

        public async Task<List<UserModel>> getList() => await _dataBase.Table<UserModel>().ToListAsync();

        public Task<int> Update(UserModel user) => _dataBase.UpdateAsync(user);

        private async void SetupDatabase()
        {
            if (_dataBase is null)
            {
                _dataBase = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
                await _dataBase.CreateTableAsync<ProductModel>();
            }
            return;
        }
    }
}
