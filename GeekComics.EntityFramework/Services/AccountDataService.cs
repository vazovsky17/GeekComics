using GeekComics.Domain.Models;
using GeekComics.Domain.Services;
using GeekComics.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;

namespace GeekComics.EntityFramework.Services
{
    public class AccountDataService : IAccountService
    {
        private readonly GeekComicsDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Account> _nonQueryDataService;

        public AccountDataService(GeekComicsDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Account>(contextFactory);
        }

        public async Task<Account> Create(Account entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<Account> Get(int id)
        {
            using (GeekComicsDbContext context = _contextFactory.CreateDbContext())
            {
                Account entity = await context.Accounts
                    .Include(a => a.AccountHolder)
                    .Include(a => a.Orders)
                    .Include(a => a.Busket)
                    .FirstOrDefaultAsync((a) => a.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using (GeekComicsDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Account> entities = await context.Accounts
                    .Include(a => a.AccountHolder)
                    .Include(a => a.Orders)
                    .Include(a => a.Busket)
                    .ToListAsync();
                return entities;
            }
        }

        // TODO: Скорей всего, нужно будет добавить пароль
        public async Task<Account> GetByUsername(string username)
        {
            using (GeekComicsDbContext context = _contextFactory.CreateDbContext())
            {
                Account entity = await context.Accounts
                    .Include(a => a.AccountHolder)
                    .Include(a => a.Orders)
                    .Include(a => a.Busket)
                    .FirstOrDefaultAsync((a) => a.AccountHolder.Username == username);
                return entity;
            }
        }

        public async Task<Account> Update(int id, Account entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
