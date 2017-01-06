using AutoMapper;
using CarsRental.Dtos;
using CarsRental.Models;
using System;
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
        public IHttpActionResult GetCars()
        {
            var carDtos = _context.Cars.ToList().Select(Mapper.Map<Car, CarDto>);
            return Ok(carDtos);
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
