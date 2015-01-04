using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExampleSite.Controllers
{
    public class ExampleController : Controller
    {
        // GET: Example
        public ActionResult Ex1()
        {
            return View("Ex1_SimpleForm");
        }
    }
}