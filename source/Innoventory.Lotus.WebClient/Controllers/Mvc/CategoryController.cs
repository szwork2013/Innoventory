﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Innoventory.Lotus.WebClient.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Categories()
        {
            return View();
        }
    }
}