namespace GeekComics.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
         
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

    }
}
