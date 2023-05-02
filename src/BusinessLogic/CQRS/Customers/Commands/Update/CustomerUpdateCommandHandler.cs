
using AutoMapper;
using BusinessLogic.Exceptions;
using Data.Repository.Entities;
using Data.Repository.Interfaces;
using MediatR;

namespace BusinessLogic.CQRS.Customers.Commands.Update
{
    public class CustomerUpdateCommandHandler : IRequestHandler<CustomerUpdateCommandRequest>
    {
        private readonly IMapper _mapper;
        private readonly IXmlImporterRepository<CustomerEntity> _customerRepository;

        public CustomerUpdateCommandHandler(IMapper mapper,
            IXmlImporterRepository<CustomerEntity> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(CustomerUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var customerToUpdate = await _customerRepository.GetAsync(request.Id);

            if (customerToUpdate == null)
            {
                throw new NotFoundException(nameof(CustomerEntity), request.Id);
            }

            customerToUpdate = new CustomerEntity 
            {
                Id = customerToUpdate.Id,
                CustomerID = request.CustomerID,
                CompanyName = request.CompanyName,
                ContactName = request.ContactName,
                ContactTitle = request.ContactTitle,
                Fax = request.Fax,
                Phone = request.Phone,
                FullAddressId = customerToUpdate.FullAddressId,
                FullAddress = new FullAddressEntity
                {
                    FullAddressId = customerToUpdate.FullAddressId,
                    Address = request.Address,
                    City = request.City,
                    Country = request.Country,
                    PostalCode = request.PostalCode,
                    Region = request.Region
                }
            };

            await _customerRepository.UpdateAsync(customerToUpdate);
            return Unit.Value;
        }
    }
}
