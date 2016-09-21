using System.Web.Mvc;

namespace CodedUIExamples.Controllers
{
    public class DecomposingPageObjectsController : Controller
    {
        // GET: DecomposingPageObjects
        public ActionResult InitialRequirements()
        {
            return View();
        }

        public ActionResult Change1()
        {
            return View("Change1PasswordHidden");
        }

        public ActionResult Change2()
        {
            return View("Change2ButtonHidden");
        }

        public ActionResult Change3()
        {
            return View("Change3OrdersPage");
        }

        public ActionResult Change4()
        {
            return View("Change4AddCancelOrders");
        }

        public ActionResult Change5()
        {
            return View("Change5QuantityDelete");
        }

        public ActionResult Change6()
        {
            return View("Change6AccountRequired");
        }
    }
}