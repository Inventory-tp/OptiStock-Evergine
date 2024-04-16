using OptiStock.MAUI.Models;

namespace OptiStock.MAUI.Repositories
{
    public interface IProductRepository
    {
        Task<int> Add(ProductModel product);
        Task<int> Update(ProductModel product);
        Task<List<ProductModel>> getList();
        Task<int> Delete(ProductModel product);
    }
}
