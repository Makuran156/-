using FinansiAPI.Controllers.DTO;
using FinansiAPI.Replicates;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Context;
using WebApplication1.Controllers.DTO;

namespace WebApplication1.Controllers
{
    public class TransactionController : BaseController
    {
        public TransactionController(ApplicationContext _appContext) : base(_appContext) { }

        [HttpGet("[controller]/[action]")]
        public JsonResult Init()
        {
            var res = GetCommon();
            return Send(true, res);
        }

        [HttpGet("[controller]/[action]")]
        public JsonResult GetTransaction()
        {
            var res = GetCommon();
            res.transaction = ApplicationContext.TransactionManagers.Transactions.Select(it => new TransactionModel(it));
            return Send(true, res);
        }

        [HttpGet("[controller]/[action]")]
        public JsonResult Get(int id)
        {
            var res = GetCommon();
            res.transaction = new TransactionModel (ApplicationContext.TransactionManagers.Transactions.FirstOrDefault(it => it.Id == id));
            return Send(true, res);
        }


        [HttpPost("[controller]/[action]")]
        public JsonResult Create([FromBody] TransactionModel model)
        {
            Transaction transaction = ApplicationContext.TransactionManagers.Create(model);
            var res = GetCommon();
            res.transactions = new TransactionModel(transaction);
            return Send(true, res);
        }


        [HttpPut("[controller]/[action]")]
        public JsonResult Update(TransactionModel model)
        {

            Transaction transaction = ApplicationContext.TransactionManagers.Update(model);
            var res = GetCommon();
            res.transactions = new TransactionModel(transaction);
            return Send(true, res);
        }


        [HttpDelete("[controller]/[action]")]
        public JsonResult Delete(int id)
        {
            ApplicationContext.TransactionManagers.Delete(id);
            var res = GetCommon();
            res.transactions = ApplicationContext.TransactionManagers.Transactions.Select(it => new TransactionModel(it));
            return Send(true, res);
        }
    }
}
