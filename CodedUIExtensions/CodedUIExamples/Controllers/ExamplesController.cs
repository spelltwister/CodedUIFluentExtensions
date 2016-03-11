using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodedUIExamples.Controllers
{
    public class ExamplesController : Controller
    {
        // GET: Examples
        public ActionResult Index()
        {
            return View();
        }

	    public ActionResult Example1()
	    {
		    return View("SimpleHtmlControls");
	    }
    }
}