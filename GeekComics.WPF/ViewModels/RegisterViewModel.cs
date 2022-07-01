using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using GeekComics.Domain.Models;
using GeekComics.WPF.Commands;
using GeekComics.WPF.State.Authentificators;
using GeekComics.WPF.State.Navigators;

namespace GeekComics.WPF.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private static IEnumerable<Role> _roles = Enum.GetValues(typeof(Role)).Cast<Role>();
        public IEnumerable<Role> Roles
        {
            get
            {
                return _roles; ;
            }
            set
            {
                _roles = value;
                OnPropertyChanged(nameof(Roles));
            }
        }

        private Role _selectedRole = _roles.First();
        public Role SelectedRole
        {
            get
            {
                return _selectedRole = _roles.First();
            }
            set
            {
                _selectedRole = value;
                OnPropertyChanged(nameof(SelectedRole));
            }
        }

        private string _username;
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
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        public bool CanRegister => !string.IsNullOrEmpty(Username)
            && !string.IsNullOrEmpty(Password)
            && !string.IsNullOrEmpty(ConfirmPassword);

        public ICommand RegisterCommand { get; }

        public ICommand ViewLoginCommand { get; }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public RegisterViewModel(IAuthenticator authenticator, IRenavigator registerRenavigator, IRenavigator loginRenavigator)
        {
            ErrorMessageViewModel = new MessageViewModel();

            RegisterCommand = new RegisterCommand(this, authenticator, registerRenavigator);
            ViewLoginCommand = new RenavigateCommand(loginRenavigator);
        }

        public override void Dispose()
        {
            ErrorMessageViewModel.Dispose();
            base.Dispose();
        }
    }
}
