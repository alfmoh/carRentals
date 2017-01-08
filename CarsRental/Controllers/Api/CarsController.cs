using AutoMapper;
using CarsRental.Dtos;
using CarsRental.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace CarsRental.Controllers.Api
{
    public class CarsController : ApiController
    {
        private ApplicationDbContext _context;

        public CarsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/cars
        public IEnumerable<CarDto> GetCars(string query = null)
        {
            var carsQuery = _context.Cars
                .Include(m => m.CarBrand)
                .Where(m => m.NumberAvailable > 0);

            if (!string.IsNullOrWhiteSpace(query))
                carsQuery = carsQuery.Where(m => m.Name.Contains(query));

            return carsQuery
                .ToList()
                .Select(Mapper.Map<Car, CarDto>);
        }

        //GET /api/cars/1       
        public IHttpActionResult GetCar(int id)
        {
            var carInDb = _context.Cars.SingleOrDefault(c => c.Id == id);
            if (carInDb == null)
                return NotFound();

            return Ok(Mapper.Map<Car, CarDto>(carInDb));
        }

        //POST /api/cars
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageCars)]
        public IHttpActionResult CreateCar(CarDto carDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var car = Mapper.Map<CarDto, Car>(carDto);
            _context.Cars.Add(car);
            _context.SaveChanges();

            carDto.Id = car.Id;
            return Created(new Uri(Request.RequestUri + "/" + car.Id), carDto);
        }

        //PUT /api/cars/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageCars)]
        public IHttpActionResult UpdateCar(int id, CarDto carDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var car = _context.Cars.SingleOrDefault(c => c.Id == id);

            if(car == null)
                return NotFound();

            Mapper.Map(carDto,car);
            _context.SaveChanges();

            return Ok();

        }

        //DELETE /api/cars/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageCars)]
        public IHttpActionResult DeleteCar(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);
            if(car == null)
                return NotFound();

            _context.Cars.Remove(car);
            _context.SaveChanges();

            return Ok();
        }



    }
}
