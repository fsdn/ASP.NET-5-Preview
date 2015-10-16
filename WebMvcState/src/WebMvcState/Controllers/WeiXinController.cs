using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMvcState.Controllers
{
    public class WeiXinController : Controller
    {
        // GET: /<controller>/

        /// <summary>
        /// WeiXin的Index页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
