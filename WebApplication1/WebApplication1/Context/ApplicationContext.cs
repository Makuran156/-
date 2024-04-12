using FinansiAPI.Managers;
using WebApplication1.Managers;
using WebApplication1.Replicates;

namespace WebApplication1.Context
{
    public class ApplicationContext
    {

        public ApplicationContext(IConfiguration config) 
        {
            Version = "0.1";
            Title = "Finansi";
            Configuration = config;
            Initialize();
        }

        public void Initialize()
        {
            /*Инициализация менедеров*/
            AccountManagers = new AccountManagers(this);
            TransactionManagers = new TransactionManagers(this);

            AccountManagers.Read();
            //TransactionManagers.Read();
        }
        public AccountManagers AccountManagers { get; set; }
        public TransactionManagers TransactionManagers { get; set; }
        public string Version { get; set; }
        public string Title { get; set; }
        public IConfiguration Configuration { get; set; }
        public DBContext CreateDbContext() => new DBContext(Configuration.GetConnectionString("DefaultConnection"));
    }
}
