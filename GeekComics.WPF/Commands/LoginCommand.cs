using System;
using System.Threading.Tasks;
using GeekComics.Domain.Exceptions;
using GeekComics.WPF.State.Authentificators;
using GeekComics.WPF.State.Navigators;
using GeekComics.WPF.ViewModels;

namespace GeekComics.WPF.Commands
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public LoginCommand(LoginViewModel loginViewModel, IAuthenticator authenticator, IRenavigator renavigator)
        {
            _loginViewModel = loginViewModel;
            _authenticator = authenticator;
            _renavigator = renavigator;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _loginViewModel.ErrorMessage = string.Empty;

            try
            {
                //TODO: Добавить подтверждение если роль админ
                await _authenticator.Login(_loginViewModel.Username, _loginViewModel.Password);
                _renavigator.Renavigate();
            }
            catch (UserNotFoundException)
            {
                _loginViewModel.ErrorMessage = "Username does not exist.";
            }
            catch (InvalidPasswordException)
            {
                _loginViewModel.ErrorMessage = "Incorrect password.";
            }
            catch (InvalidAdministrationCodeException)
            {
                _loginViewModel.ErrorMessage = "Incorrect administration code.";
            }
            catch (Exception ex)
            {
                //TODO: Убрать ex.Message
                _loginViewModel.ErrorMessage = "Login failed." + ex.Message;
            }
        }
    }
}
