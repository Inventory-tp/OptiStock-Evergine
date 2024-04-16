using OptiStock.MAUI.Models;
using SQLite;

namespace OptiStock.MAUI.Repositories
{
    public class ProductRepositoryImpl : IProductRepository
    {
        private SQLiteAsyncConnection _dataBase;

        public ProductRepositoryImpl() {
            SetupDatabase();
        }

        public async Task<int> Add(ProductModel product) => await _dataBase.InsertAsync(product);

        public async Task<int> Delete(ProductModel product) => await _dataBase.DeleteAsync(product);
        

        public async Task<List<ProductModel>> getList() => await _dataBase.Table<ProductModel>().ToListAsync();
        

        public async Task<int> Update(ProductModel product) => await _dataBase.UpdateAsync(product);

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
