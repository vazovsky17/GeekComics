﻿using System.Windows.Input;
using GeekComics.Domain.Models;
using GeekComics.WPF.Commands;
using GeekComics.WPF.State.Authentificators;
using GeekComics.WPF.State.Navigators;

namespace GeekComics.WPF.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
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

        private Role _role;
        public Role Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
                OnPropertyChanged(nameof(Role));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        public bool CanRegister => !string.IsNullOrEmpty(Username)
            && !string.IsNullOrEmpty(Password)
            && !string.IsNullOrEmpty(ConfirmPassword)
            && Role != null;

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
