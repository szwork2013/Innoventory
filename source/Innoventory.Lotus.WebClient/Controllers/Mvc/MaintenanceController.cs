using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Innoventory.Lotus.WebClient.Controllers.Mvc
{
    public class MaintenanceController : Controller
    {
        // GET: Maintenance
        public ActionResult Categories()
        {
            return View();
        }

        public ActionResult SubCategories()
        {
            return View();
        }

        public ActionResult VolumeMeasures()
        {
            return View();
        }

        public ActionResult ProductAttributes()
        {
            return View();
        }
               

        public ActionResult Products()
        {
            return View();
        }

        public ActionResult Customers()
        {
            return View();
        }

        public ActionResult Suppliers()
        {
            return View();
        }
    }
}