using FinansiAPI.Replicates;
using System.Transactions;
using WebApplication1.Replicates;
using Transaction = FinansiAPI.Replicates.Transaction;

namespace FinansiAPI.Controllers.DTO
{
    public class TransactionModel
    {
        public TransactionModel() { }
        public TransactionModel(Transaction context)
        {
            id = context.Id;
            Cost = context.Cost;
            Plus = context.Plus;
        }
        public int id { get; }
        public int Cost { get; set; }
        public string Plus { get; set; }
    }
}
