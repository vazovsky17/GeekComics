using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekComics.WPF.ViewModels.Factories
{
    public class ProfileViewModelFactory : IGeekComicsViewModelFactory<ProfileViewModel>
    {
        public ProfileViewModel CreateViewModel()
        {
            return new ProfileViewModel();
        }
    }
}
