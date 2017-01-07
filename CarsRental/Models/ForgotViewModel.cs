using System.ComponentModel.DataAnnotations;

namespace CarsRental.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}