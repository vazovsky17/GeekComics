using System;
using System.Threading.Tasks;
using GeekComics.Domain.Models;
using GeekComics.Domain.Services.AuthentificationServices;
using GeekComics.WPF.State.Accs;

namespace GeekComics.WPF.State.Authentificators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountStore _accountStore;

        public Authenticator(IAuthenticationService authenticationService, IAccountStore accountStore)
        {
            _authenticationService = authenticationService;
            _accountStore = accountStore;
        }


        public Account CurrentAccount
        {
            get
            {
                return _accountStore.CurrentAccount;
            }
            private set
            {
                _accountStore.CurrentAccount = value;
                StateChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => CurrentAccount != null;

        public event Action StateChanged;

        public async Task Login(string username, string password)
        {
            CurrentAccount = await _authenticationService.Login(username, password);
        }

        public void Logout()
        {
            CurrentAccount = null;
        }

        public async Task<RegistrationResult> Register(string username, string password, string confirmPassword, Role role)
        {
            return await _authenticationService.Register(username, password, confirmPassword, role);
        }
    }
}
