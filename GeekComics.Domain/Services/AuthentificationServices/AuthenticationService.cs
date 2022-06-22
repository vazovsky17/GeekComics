using GeekComics.Domain.Exceptions;
using GeekComics.Domain.Models;
using Microsoft.AspNet.Identity;

namespace GeekComics.Domain.Services.AuthentificationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IAccountService accountService, IPasswordHasher passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }

        public async Task<Account> Login(string username, string password)
        {
            Account storedAccount = await _accountService.GetByUsername(username);
            if (storedAccount == null)
            {
                throw new UserNotFoundException(username);
            }

            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedAccount.AccountHolder.PasswordHash, password);
            if (passwordResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(username, password);
            }

            return storedAccount;
        }

        public async Task<RegistrationResult> Register(string username, string password, string confirmPassword)
        {
            RegistrationResult result = RegistrationResult.Success;
            if (password != confirmPassword)
            {
                result = RegistrationResult.PasswordsDoNotMatch;
            }

            Account storedAccount = await _accountService.GetByUsername(username);
            if (storedAccount != null)
            {
                result = RegistrationResult.PasswordsDoNotMatch;
            }

            if (result == RegistrationResult.Success)
            {
                string hashedPassword = _passwordHasher.HashPassword(password);
                User user = new()
                {
                    Username = username,
                    PasswordHash = hashedPassword,
                };

                Account account = new()
                {
                    AccountHolder = user,
                    BonusCount = 500,
                };

                await _accountService.Create(account);
            }

            return result;
        }
    }
}
