using FinansiAPI.Controllers.DTO;
using FinansiAPI.Replicates;
using WebApplication1.Context;
using WebApplication1.Controllers.DTO;
using WebApplication1.Models;
using WebApplication1.Replicates;

namespace FinansiAPI.Managers
{
    public class TransactionManagers
    {

        protected ApplicationContext ApplicationContext { get; set; }
        protected DBContext DBContext { get; set; }

        public TransactionManagers(ApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;
            DBContext = ApplicationContext.CreateDbContext();
        }
        private List<Transaction> _transactions { get; set; } = new List<Transaction>();

        public Transaction[] Transactions { get => _transactions.ToArray(); }
        public bool Read()
        {
            try
            {
                foreach (EFTransaction item in DBContext.Transaction)
                {
                    if (item.IsDeleted != true) _transactions.Add(new Transaction(item));
                }
                return true;
            }
            catch { throw; }
        }
        public Transaction Get(int id) => _transactions.FirstOrDefault(it => it.Id == id);

        public Transaction Create(TransactionModel model)
        {
            try
            {
                EFTransaction transaction = new EFTransaction()
                {
                    
                    Cost = model.Cost,
                    Plus = model.Plus,
                };
                DBContext.Add(transaction);
                DBContext.SaveChanges();

                Transaction replicate = new Transaction(transaction);
                _transactions.Add(replicate);
                
                return replicate;
            }
            catch { throw; }
        }

        public Transaction Update(TransactionModel model)
        {
            try
            {
                EFTransaction _transaction = DBContext.Transaction.FirstOrDefault(it => it.Id == model.id);

                _transaction.Cost = model.Cost;
                _transaction.Plus = model.Plus;

                DBContext.Update(_transaction);
                _transactions.Remove(_transactions.FirstOrDefault(it => it.Id == model.id));
                Transaction repl = new Transaction(_transaction);
                _transactions.Add(repl);

                return repl;
            }
            catch { throw; }
        }

        public bool Delete(int id)
        {
            try
            {
                EFTransaction _transaction = DBContext.Transaction.FirstOrDefault(it => it.Id == id);
                _transaction.IsDeleted = true;
                DBContext.Update(_transaction);

                _transactions.Remove(_transactions.FirstOrDefault(it => it.Id == id));
                return true;
            }
            catch { throw; }

        }
    }
}