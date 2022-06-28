using System;
using GeekComics.Domain.Models;

namespace GeekComics.WPF.State.Accs
{
    public interface IAccountStore
    {
        Account CurrentAccount { get; set; }
        event Action StateChanged;
    }
}
