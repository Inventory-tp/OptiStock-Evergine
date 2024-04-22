using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OptiStock.MAUI.Database;
using OptiStock.MAUI.Exceptions;
using OptiStock.MAUI.Models;

namespace OptiStock.MAUI.Services.Common
{
    //Service class of generic nonquery action to the database
    //Generic : It meens that every Entity could use this service
    //<using (OptiStockDbContext context = _contextFactory.CreateDbContext())> => create new context for each call to the database
    public class NonQueryDataService<T> where T : DomainObject
    {

        private readonly OptiStockDbContextFactory _contextFactory;

        //Database Factory injection through the constructor class
        public NonQueryDataService(OptiStockDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        //Create() : Generic method to create an entry in the database from a generic object
        //Result class type is Success or Failure depending of the process result
        public async Task<Result<T>> Create(T entity)
        {
            using (OptiStockDbContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    EntityEntry<T> creationEntry = await context.Set<T>().AddAsync(entity) ?? throw GenericExceptions.CreationException;
                    await context.SaveChangesAsync();

                    return Result<T>.Success(creationEntry.Entity);
                }
                catch (Exception ex)
                {
                    return Result<T>.Failure(ex);
                }
            };
        }

        //Delete() : Generic method to delete an entry in the database from an ID
        //Result class type is Success or Failure depending of the process result
        public async Task<Result<bool>> Delete(Guid id)
        {
            using (OptiStockDbContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id) ?? throw GenericExceptions.CreationException;
                    context.Set<T>().Remove(entity);
                    await context.SaveChangesAsync();
                    if (await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id) != null)
                    {
                        throw GenericExceptions.UnexpectedException;
                    }

                    return Result<bool>.Success();
                }
                catch (Exception ex)
                {
                    return Result<bool>.Failure(ex);
                }
            };
        }

        //Update() : Generic method to update an entry in the database from an ID and a generic object
        //Result class type is Success or Failure depending of the process result
        public async Task<Result<T>> Update(Guid id, T entity)
        {
            using (OptiStockDbContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    entity.Id = id;
                    EntityEntry<T> updateEntry = context.Set<T>().Update(entity) ?? throw GenericExceptions.UpdateException;
                    await context.SaveChangesAsync();
                    if (entity.Id != id)
                    {
                        throw GenericExceptions.UnexpectedException;
                    }
                    
                    return Result<T>.Success(updateEntry.Entity);
                }
                catch (Exception ex) 
                {
                    return Result<T>.Failure(ex);
                }
            };
        }
    }
}
