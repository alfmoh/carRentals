using System;
using System.ComponentModel.DataAnnotations;

namespace CarsRental.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public int NumberInStock { get; set; }

        public CarBrand CarBrand { get; set; }

        [Display(Name = "Car Model")]
        [Required]       
        public byte CarBrandId { get; set; }
    }
}