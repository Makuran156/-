using WebApplication1.Models;

namespace FinansiAPI.Replicates
{
    public class Transaction
    {
        
        private EFTransaction Context { get; set; }
        public Transaction(EFTransaction context) { Context = context; }
        public int Id { get => Context.Id; }
        public int Cost { get => Context.Cost; set => Context.Cost = value; }
        public string Plus { get => Context.Plus; set => Context.Plus = value; }
    }
}


