using GeekComics.Domain.Exceptions;
using GeekComics.Domain.Models;
using Microsoft.AspNet.Identity;

namespace GeekComics.Domain.Services.AuthentificationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        // TODO: Засунуть код администрации в сеттинги
        private readonly string AdministrationCode = "883306";
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IAccountService accountService, IPasswordHasher passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }

        public async Task<Account> Login(string username, string password, string? administrationCode = null)
        {
            if (administrationCode != AdministrationCode && administrationCode != null)
            {
                throw new InvalidAdministrationCodeException();
            }

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

        public async Task<RegistrationResult> Register(string username, string password, string confirmPassword, Role role, string? administrationCode = null)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (administrationCode != AdministrationCode && administrationCode != null)
            {
                result = RegistrationResult.InvalidAdministrationCode;
            }

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
