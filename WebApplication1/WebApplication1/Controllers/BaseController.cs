using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using WebApplication1.Context;

namespace WebApplication1.Controllers
{
    public class BaseController: Controller
    {
        public ApplicationContext ApplicationContext { get; set; }

        public BaseController(ApplicationContext applicationContext)
        {
            ApplicationContext=applicationContext;
        }

        internal dynamic GetCommon() => new ExpandoObject();

        internal JsonResult Send(bool status, object data)
        {
            return new JsonResult(new 
            {status = status,
             data = data, 
             datetime = DateTime.Now.ToString()
            });
        }
    }
}
