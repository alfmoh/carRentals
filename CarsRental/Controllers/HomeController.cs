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

    }
}