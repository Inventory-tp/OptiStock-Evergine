using Microsoft.EntityFrameworkCore;
using OptiStock.MAUI.Database;
using OptiStock.MAUI.Exceptions;
using OptiStock.MAUI.Models;
using OptiStock.MAUI.Services.Common;

namespace OptiStock.MAUI.Services
{
    //Service class of generic action to the database
    //Implementing the IDataRepository interface
    //Generic : It meens that every Entity could use this service
    //<using (OptiStockDbContext context = _contextFactory.CreateDbContext())> => create new context for each call to the database
    public class GenericDataService<T> : IDataRepository<T> where T : DomainObject
    {
        private readonly OptiStockDbContextFactory _contextFactory;
        private readonly NonQueryDataService<T> _nonQueryDataService;

        //Class constructor with OptiStockDbContextFactory class and NonQueryDataService class parameters
        public GenericDataService(OptiStockDbContextFactory contextFactory, NonQueryDataService<T> nonQueryDataService)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = nonQueryDataService;
        }

        //Create() : generic method to create an entry in the database
        public async Task<Result<T>> Create(T entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        //Delete() : generic method to delete an entry in the database
        public async Task<Result<bool>> Delete(Guid id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        //Update() : generic method to update an entry in the database
        public async Task<Result<T>> Update(Guid id, T entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        //GetAll() : generic method to get an iteration of X number of entry in the database
        public async Task<Result<IEnumerable<T>>> GetAll()
        {
            using (OptiStockDbContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<T> entities = await context.Set<T>().ToListAsync() ?? throw GenericExceptions.GetAllException;
                    return Result<IEnumerable<T>>.Success(entities);
                }
                catch (Exception ex)
                {
                    return Result<IEnumerable<T>>.Failure(ex);
                }
            };
        }

        //GetById() : generic method to get an entry in the database from an ID
        public async Task<Result<T>> GetById(Guid id)
        {
            using (OptiStockDbContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id) ?? throw GenericExceptions.GetByIdException;
                    return Result<T>.Success(entity);
                } catch (Exception ex)
                {
                    return Result<T>.Failure(ex);
                }
            };
        }
    }
}
