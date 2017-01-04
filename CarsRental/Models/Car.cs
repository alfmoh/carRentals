using System;
using System.ComponentModel.DataAnnotations;

namespace CarsRental.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int NumberInStock { get; set; }

        [Display(Name = "Car Model")]
        public CarBrand CarBrand { get; set; }
        public byte CarBrandId { get; set; }
    }
}