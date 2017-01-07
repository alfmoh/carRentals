using AutoMapper;
using CarsRental.Dtos;
using CarsRental.Models;

namespace CarsRental.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Car, CarDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<CarBrand, CarBrandDto>();
            //Mapper.CreateMap<Rental, NewRentalDto>();

            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c=>c.Id, opt=>opt.Ignore());          
            Mapper.CreateMap<CarDto, Car>().ForMember(c=>c.Id,opt=>opt.Ignore());
            Mapper.CreateMap<MembershipTypeDto, MembershipType>();
            Mapper.CreateMap<CarBrandDto, CarBrand>();
            //Mapper.CreateMap<NewRentalDto, Rental>();
        }
    }
}