using System;
using System.ComponentModel.DataAnnotations;

namespace CarsRental.Dtos
{
    public class CarDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Range(1, 20)]
        public int NumberInStock { get; set; }

        public CarBrandDto CarBrand { get; set; }

        [Required]
        public byte CarBrandId { get; set; }
    }
}