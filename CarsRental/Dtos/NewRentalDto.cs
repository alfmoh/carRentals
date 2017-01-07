using System.Collections.Generic;

namespace CarsRental.Dtos
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> CarIds { get; set; }
    }
}