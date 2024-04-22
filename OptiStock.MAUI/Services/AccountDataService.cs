using Microsoft.EntityFrameworkCore;
using OptiStock.MAUI.Database;
using OptiStock.MAUI.Exceptions;
using OptiStock.MAUI.Models;
using OptiStock.MAUI.Services.Common;

namespace OptiStock.MAUI.Services
{
    //Service class for the account object action to the database
    //Implementing the IAccountRepository interface
    //<using (OptiStockDbContext context = _contextFactory.CreateDbContext())> => create new context for each call to the database
    public class AccountDataService : IAccountRepository
    {
        private readonly OptiStockDbContextFactory _contextFactory;
        private readonly NonQueryDataService<AccountModel> _nonQueryDataService;

        //Class constructor with OptiStockDbContextFactory class and NonQueryDataService class parameters
        public AccountDataService(OptiStockDbContextFactory contextFactory, NonQueryDataService<AccountModel> nonQueryDataService)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = nonQueryDataService;
        }

        //Create() : AccountModel method to create an account entry in the database
        public async Task<Result<AccountModel>> Create(AccountModel entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        //Delete() : AccountModel method to delete an account entry in the database
        public async Task<Result<bool>> Delete(Guid id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        //Update() : AccountModel method to update an account entry in the database
        public async Task<Result<AccountModel>> Update(Guid id, AccountModel entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        //GetAll() : AccountModel method to get an iteration of X number of account entry in the database
        public async Task<Result<IEnumerable<AccountModel>>> GetAll()
        {
            using (OptiStockDbContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    IEnumerable<AccountModel> entities = await context.Accounts.ToListAsync() ?? throw GenericExceptions.GetAllException;
                    return Result<IEnumerable<AccountModel>>.Success(entities);
                }
                catch (Exception ex)
                {
                    return Result<IEnumerable<AccountModel>>.Failure(ex);
                }
            };
        }

        //GetById() : AccountModel method to get an account entry in the database from an ID
        public async Task<Result<AccountModel>> GetById(Guid id)
        {
            using (OptiStockDbContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    AccountModel entities = await context.Accounts.FirstOrDefaultAsync((e) => e.Id == id) ?? throw GenericExceptions.GetByIdException;
                    return Result<AccountModel>.Success(entities);
                }
                catch (Exception ex)
                {
                    return Result<AccountModel>.Failure(ex);
                }
            };
        }

        //GetByUsername() : AccountModel method to retrieve an account entry in the database by its username
        public async Task<Result<AccountModel>> GetByUsername(string username)
        {
            using (OptiStockDbContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    AccountModel entity = await context.Accounts
                        .Include(accountModel => accountModel.AccountHolder)
                        .FirstOrDefaultAsync(accountModel => accountModel.AccountHolder.Username == username) 
                        ?? throw GenericExceptions.GetByIdException;

                    return Result<AccountModel>.Success(entity);
                }
                catch (Exception ex)
                {
                    return Result<AccountModel>.Failure(ex);
                }
            };
        }
        //GetByUsername() : AccountModel method to retrieve an account entry in the database by its email
        public async Task<Result<AccountModel>> GetByEmail(string email)
        {
            using (OptiStockDbContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    AccountModel entity = await context.Accounts
                        .Include(accountModel => accountModel.AccountHolder)
                        .FirstOrDefaultAsync(accountModel => accountModel.AccountHolder.Email == email)
                        ?? throw GenericExceptions.GetByIdException;

                    return Result<AccountModel>.Success(entity);
                }
                catch (Exception ex)
                {
                    return Result<AccountModel>.Failure(ex);
                }
            };
        }
    }
}
