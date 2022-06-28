using System.Windows.Input;
using GeekComics.WPF.Commands;
using GeekComics.WPF.State.Authentificators;
using GeekComics.WPF.State.Navigators;

namespace GeekComics.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        //TODO: убрать стандартный юзернейм
        private string _username = "Vazovsky17";
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel(IAuthenticator authenticator, IRenavigator renavigator)
        {
            ErrorMessageViewModel = new MessageViewModel();

            LoginCommand = new LoginCommand(this, authenticator, renavigator);
        }
    }
}
