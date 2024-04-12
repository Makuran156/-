using WebApplication1.Context;
using WebApplication1.Controllers.DTO;
using WebApplication1.Models;
using WebApplication1.Replicates;

namespace WebApplication1.Managers
{
    public class AccountManagers
    {

        protected ApplicationContext ApplicationContext { get; set; }
        protected DBContext DBContext { get; set; }

        public AccountManagers (ApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;
            DBContext = ApplicationContext.CreateDbContext ();
        }
        private List<Account> _accounts { get; set; } = new List<Account> ();

        public Account[] Accounts { get => _accounts.ToArray(); }
        public bool Read()
        {
            try
            {
                foreach (EFAccount item in DBContext.Account)
                {
                    if (item.IsDeleted != true) _accounts.Add(new Account(item));
                }
                return true;
            }catch { throw;  }
        }
        public Account Get(int id) => _accounts.FirstOrDefault(it => it.Id == id);

        public Account Create(AccountModel model)
        {
            try
            {
                EFAccount account = new EFAccount()
                {
                    Name = model.Name,
                    Balans = model.Balans,
                };
                DBContext.Add(account);
                DBContext.SaveChanges();

                Account replicate = new Account(account);
                _accounts.Add(replicate);

                return replicate;
            }catch { throw; }
        }

        public Account Update(AccountModel model)
        {
            try
            {
                EFAccount _account = DBContext.Account.FirstOrDefault(it => it.Id == model.id);

                _account.Name = model.Name;
                _account.Balans = model.Balans;

                DBContext.Update(_account);
                _accounts.Remove(_accounts.FirstOrDefault(it => it.Id == model.id));
                Account repl = new Account(_account);
                _accounts.Add(repl);

                return repl;
            }
            catch { throw; }
        }

        public bool Delete(int id)
        {
            try
            {
                EFAccount _account = DBContext.Account.FirstOrDefault(it => it.Id == id);
                _account.IsDeleted = true;
                DBContext.Update(_account);

                _accounts.Remove(_accounts.FirstOrDefault(it => it.Id == id));
                return true;
            }
            catch { throw; }
            
        }
    }
}
