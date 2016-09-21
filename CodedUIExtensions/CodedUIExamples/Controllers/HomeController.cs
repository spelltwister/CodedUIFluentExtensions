using System.Web.Mvc;

namespace CodedUIExamples.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Fluent()
		{
			return View("FluentDetails");
		}

		public ActionResult PageModeling()
		{
			return View();
		}

		public ActionResult CodedUIPageModeling()
		{
			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}