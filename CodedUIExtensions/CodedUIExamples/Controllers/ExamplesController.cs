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

        public ActionResult Example2()
        {
            return View("ChildExample");
        }

        public ActionResult Legacy()
        {
            return View();
        }
    }
}