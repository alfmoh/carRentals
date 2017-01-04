using CarsRental.Models;
using System.Collections.Generic;

namespace CarsRental.ViewModels
{
    public class RandomCarViewModel
    {
        public Car Car { get; set; }
        public List<Customer> Customers { get; set; }
    }
}