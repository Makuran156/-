using WebApplication1.Models;

namespace WebApplication1.Replicates
{
    public class Account
    {
        private EFAccount Context { get; set; }
        public Account(EFAccount context) { Context = context; }
        public int Id { get => Context.Id; }
        public string Name { get => Context.Name; set => Context.Name = value; }
        public int Balans { get => Context.Balans; set => Context.Balans = value; }
    }
}
