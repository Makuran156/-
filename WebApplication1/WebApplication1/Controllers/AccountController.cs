using FinansiAPI.Controllers.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Context;
using WebApplication1.Controllers.DTO;
using WebApplication1.Replicates;

namespace WebApplication1.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(ApplicationContext _appContext) : base(_appContext) { }

    [HttpGet("[controller]/[action]")]
        public JsonResult GetAll()
        {
            var res = GetCommon();
            res.accounts = ApplicationContext.AccountManagers.Accounts.Select(it => new AccountModel(it));
            return Send(true, res);
        }
        [HttpPost("[controller]/[action]")]
        public JsonResult Creat([FromBody] AccountModel model)
        {
            Account account = ApplicationContext.AccountManagers.Create(model);
            var res = GetCommon();
            res.transactions = new AccountModel(account);
            return Send(true, res);
        }

    }
}
