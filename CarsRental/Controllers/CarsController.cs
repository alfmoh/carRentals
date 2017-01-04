using CarsRental.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace CarsRental.Controllers
{
    public class CarsController : Controller
    {
        private ApplicationDbContext _context;

        public CarsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Cars
        public ActionResult Index()
        {
            var car = _context.Cars.Include(c => c.CarBrand).ToList();

            return View(car);
        }

        
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/ "+ month);
        }


        public ActionResult Details(int id)
        {
            var car = _context.Cars.Include(c=>c.CarBrand).SingleOrDefault(c => c.Id == id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }
    }
}