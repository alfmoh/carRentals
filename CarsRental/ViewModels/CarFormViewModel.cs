using CarsRental.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarsRental.ViewModels
{
    public class CarFormViewModel
    {
        public IEnumerable<CarBrand> CarBrand { get; set; }

        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        [Required]
        public DateTime? DateAdded { get; set; }

        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        [Required]
        public int? NumberInStock { get; set; }

        [Display(Name = "Car Model")]
        [Required]
        public byte? CarBrandId { get; set; }

        public string Title => Id != 0 ? "Edit Car" : "New Car";

        public CarFormViewModel()
        {
            Id = 0;
        }

        public CarFormViewModel(Car car)
        {
            Id = car.Id;
            Name = car.Name;
            CarBrandId = car.CarBrandId;
            ReleaseDate = car.ReleaseDate;
            DateAdded = car.DateAdded;
            NumberInStock = car.NumberInStock;
        }
    }

}