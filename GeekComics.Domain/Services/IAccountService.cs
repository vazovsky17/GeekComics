using GeekComics.Domain.Models;

namespace GeekComics.Domain.Services
{
    public interface IAccountService : IDataService<Account>
    {
        Task<Account> GetByUsername(string username);
    }
}
