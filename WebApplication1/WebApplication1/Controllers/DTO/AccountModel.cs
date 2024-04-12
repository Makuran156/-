using WebApplication1.Replicates;

namespace WebApplication1.Controllers.DTO
{
    public class AccountModel
    {
        public AccountModel() { }
        public AccountModel(Account context) 
        {
            id = context.Id;
            Name = context.Name;
            Balans = context.Balans;
        }
        public int id { get; }
        public string Name { get; set; }
        public int Balans { get; set; }
    }
}
