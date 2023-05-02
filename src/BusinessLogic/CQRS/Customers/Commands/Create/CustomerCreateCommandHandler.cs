
using AutoMapper;
using Data.Repository.Entities;
using Data.Repository.Interfaces;
using MediatR;
using XmlDataExtractManager;

namespace BusinessLogic.CQRS.Customers.Commands.Create
{
    public class CustomerCreateCommandHandler : IRequestHandler<CustomerCreateCommandRequest, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IXmlImporterRepository<CustomerEntity> _customerRepository;

        public CustomerCreateCommandHandler(IMapper mapper,
            IXmlImporterRepository<CustomerEntity> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<Guid> Handle(CustomerCreateCommandRequest request, CancellationToken cancellationToken)
        {

            CustomerEntity customer = new CustomerEntity 
            {
                CustomerID = request.CustomerID,
                CompanyName = request.CompanyName,
                ContactName = request.ContactName,
                ContactTitle = request.ContactTitle,
                Fax = request.Fax,
                Phone = request.Phone,
                FullAddress = new FullAddressEntity
                {
                    Address = request.Address,
                    City    = request.City,
                    Country = request.Country,
                    PostalCode = request.PostalCode,
                    Region = request.Region
                } 
            };

            customer = await _customerRepository.AddAsync(customer);

            return customer.Id;
        }
    }
}
