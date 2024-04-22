using Microsoft.AspNetCore.Identity;
using OptiStock.MAUI.Exceptions;
using OptiStock.MAUI.Models;
using OptiStock.MAUI.Services.Common;

namespace OptiStock.MAUI.Services.Authentication
{
    //AuthenticationService class of authentication action to the database
    public class AuthenticationService : IAuthenticationRepository
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher<AccountModel> _passwordAccountHasher;
        private readonly IPasswordHasher<UserModel> _passwordUserHasher;
        public AuthenticationService(IAccountRepository accountRepository, IPasswordHasher<AccountModel> passwordAccountHasher, IPasswordHasher<UserModel> passwordUserHasher)
        {
            _accountRepository = accountRepository;
            _passwordAccountHasher = passwordAccountHasher;
            _passwordUserHasher = passwordUserHasher;
        }

        //Login method, checking if the username and the password provided are rights
        //This method have return type of Result<> object which can be either Success or Failure
        public async Task<Result<AccountModel>> Login(string username, string password)
        {
            try
            {
                Result<AccountModel> storedAccount = await _accountRepository.GetByUsername(username) ?? throw AccountDataServiceExceptions.UserDoesntExistException;
                if(storedAccount.IsFailure)
                {
                    throw storedAccount.Error.InnerException;
                }

                AccountModel _entity = new();

                Result<AccountModel>.Match(
                    storedAccount,
                    onSuccess: (entity) => entity =_entity,
                    onFailure: (error) => throw error);

                PasswordVerificationResult passwordsMatch = _passwordAccountHasher.VerifyHashedPassword(_entity, _entity.AccountHolder.Password, password);

                if (passwordsMatch == PasswordVerificationResult.Failed)
                {
                    throw AccountDataServiceExceptions.PasswordIsWrongException;
                }
                
                return Result<AccountModel>.Success(_entity);

            } catch (Exception ex)
            {
                return Result<AccountModel>.Failure(ex);
            }
        }

        //Register Method, verification that passwords are equals, email and username doesn't already exist
        //This method have return type of Result<> object which can be either Success or Failure
        public async Task<Result<bool>> Register(string email, string username, string password, string confirmPassword, UsersRights rights)
        {
            try
            {
                if(password != confirmPassword)
                {
                    throw AccountDataServiceExceptions.PasswordsMisMatchException;
                }

                Result<AccountModel> emailUser = await _accountRepository.GetByEmail(email);

                if(emailUser != null)
                {
                    throw AccountDataServiceExceptions.EmailAlreadyUsedException;
                }

                Result<AccountModel> usernameUser = await _accountRepository.GetByUsername(username);

                if (username != null)
                {
                    throw AccountDataServiceExceptions.UsernameAlreadyUsedException;
                }

                UserModel user = new()
                {
                    Email = email,
                    Username = username,
                    Rights = rights,
                };

                user.Password = _passwordUserHasher.HashPassword(user, password);

                AccountModel account = new()
                {
                    AccountHolder = user,
                };

                await _accountRepository.Create(account);

                return Result<bool>.Success();
            }
            catch (Exception ex) 
            {
                return Result<bool>.Failure(ex);
            }
        }
    }
}
