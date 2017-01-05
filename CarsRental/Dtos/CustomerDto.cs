using CarsRental.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarsRental.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        
        [Min20YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        
        public byte MembershipTypeId { get; set; }
    }
}