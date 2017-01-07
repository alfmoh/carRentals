using CarsRental.Dtos;
using CarsRental.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace CarsRental.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (newRental.CarIds.Count == 0)
                return BadRequest("No Car Ids have been given");

            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);

            if (customer == null)
                return BadRequest("Customer Id is not valid");           

            var cars = _context.Cars.Where(c => newRental.CarIds.Contains(c.Id)).ToList();

            if (cars.Count != newRental.CarIds.Count)
                return BadRequest("One or more car ids are invalid");

            foreach (var car in cars)
            {
                if (car.NumberAvailable == 0)
                    return BadRequest("Car is not available");

                car.NumberAvailable--;

                var rental = new Rental
                {
                    Car = car,
                    Customer = customer,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();

            return Ok();
        }
    }
}
