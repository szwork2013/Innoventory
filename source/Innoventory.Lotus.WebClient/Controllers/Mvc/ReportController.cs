using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Innoventory.Lotus.WebClient.Controllers.Mvc
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult CustomerOrders()
        {
            return View();
        }

        public ActionResult SalesReport()
        {
            return View();
        }
    }
}