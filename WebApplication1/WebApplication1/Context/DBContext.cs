using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
namespace WebApplication1.Context
{
    public class DBContext:DbContext
    {

        /*Перечисление моделей(таблиц)*/
        public DbSet<EFAccount> Account { get; set; }

        public DbSet<EFTransaction> Transaction { get; set; }

        public DBContext(string conString)
        {
            ConnectionString = conString;
            Database.EnsureCreated();
        }

        public string ConnectionString {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
