using OptiStock.MAUI.Services.Common;

namespace OptiStock.MAUI.Services
{
    public interface IDataRepository<T>
    {
        Task<Result<IEnumerable<T>>> GetAll();
        Task<Result<T>> GetById(Guid id);
        Task<Result<T>> Create(T entity);
        Task<Result<T>> Update(Guid id, T entity);
        Task<Result<bool>> Delete(Guid id);
    }
}
