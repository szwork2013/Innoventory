using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Innoventory.Lotus.WebClient.Controllers.Mvc
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult PurchaseOrders()
        {
            return View();
        }

        public ActionResult SalesOrders()
        {
            return View();
        }
    }
}