using AutoMapper;
using CarsRental.Dtos;
using CarsRental.Models;

namespace CarsRental.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}