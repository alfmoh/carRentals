using CarsRental.Models;
using System.Collections.Generic;

namespace CarsRental.ViewModels
{
    public class CarFormViewModel
    {
        public IEnumerable<CarBrand> CarBrand { get; set; }
        public Car Car { get; set; }

        public string Title => Car == null ? "New Car" : "Edit Car";
    }
}