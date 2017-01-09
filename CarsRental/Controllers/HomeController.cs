using System.Web.Mvc;

namespace CarsRental.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Cars");
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is a Car Rentals application";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Our Contacts";

            return View();
        }
    }
}