
using AutoMapper;
using BusinessLogic.CQRS.Customers.Commands.Create;
using BusinessLogic.CQRS.Customers.Commands.Update;
using BusinessLogic.CQRS.Customers.Dtos;
using BusinessLogic.CQRS.Customers.Queries.GetDetails;
using BusinessLogic.CQRS.Customers.Queries.GetList;
using BusinessLogic.CQRS.FullAddresses.Dtos;
using Data.Repository.Entities;

namespace BusinessLogic.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerEntity, CustomerDto>();
            CreateMap<CustomerEntity, CustomerListVm>();
            CreateMap<CustomerEntity, CustomerCreateCommandRequest>().ReverseMap();
            CreateMap<CustomerEntity, CustomerUpdateCommandRequest>().ReverseMap();
            CreateMap<CustomerEntity, CustomerDetailVm>().ReverseMap();
            CreateMap<FullAddressEntity, FullAddressDto>();
        }
    }
}
