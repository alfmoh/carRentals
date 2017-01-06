using CarsRental.Models;
using CarsRental.ViewModels;
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


        public ActionResult Details(int id)
        {
            var car = _context.Cars.Include(c=>c.CarBrand).SingleOrDefault(c => c.Id == id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        public ActionResult New()
        {
            var carBrands = _context.CarBrands.ToList();
            var viewModel = new CarFormViewModel
            {
                
                CarBrand = carBrands
            };

            return View("CarForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Car car)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CarFormViewModel(car)
                {    
                    CarBrand = _context.CarBrands.ToList()
                };

                return View("CarForm", viewModel);
            }

            if (car.Id == 0)
            {
                _context.Cars.Add(car);
            }
            else
            {
                var carInDb = _context.Cars.Single(c => c.Id == car.Id);
                carInDb.Name = car.Name;
                carInDb.CarBrandId = car.CarBrandId;
                carInDb.NumberInStock = car.NumberInStock;
                carInDb.ReleaseDate = car.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Cars");
        }

        public ActionResult Edit(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);
            if (car == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CarFormViewModel(car)
            {               
                CarBrand = _context.CarBrands.ToList()
            };

            return View("CarForm", viewModel);
        }
    }
}