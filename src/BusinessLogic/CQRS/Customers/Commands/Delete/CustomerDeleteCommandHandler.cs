
using AutoMapper;
using BusinessLogic.Exceptions;
using Data.Repository.Entities;
using Data.Repository.Interfaces;
using MediatR;

namespace BusinessLogic.CQRS.Customers.Commands.Delete
{
    public class CustomerDeleteCommandHandler : IRequestHandler<CustomerDeleteCommandRequest>
    {
        private readonly IMapper _mapper;
        private readonly IXmlImporterRepository<CustomerEntity> _customerRepository;

        public CustomerDeleteCommandHandler(IMapper mapper,
            IXmlImporterRepository<CustomerEntity> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(CustomerDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            var customerToDelete = await _customerRepository.GetAsync(request.Id);

            if (customerToDelete == null)
            {
                throw new NotFoundException(nameof(CustomerEntity), request.Id);
            }
            await _customerRepository.DeleteAsync(customerToDelete);
            return Unit.Value;
        }
    }
}
