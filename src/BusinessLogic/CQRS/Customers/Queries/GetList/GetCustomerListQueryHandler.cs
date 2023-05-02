using AutoMapper;
using Data.Repository.Entities;
using Data.Repository.Interfaces;
using MediatR;

namespace BusinessLogic.CQRS.Customers.Queries.GetList
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQueryRequest, List<CustomerListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IXmlImporterRepository<CustomerEntity> _customerRepository;

        public GetCustomerListQueryHandler(IMapper mapper,
            IXmlImporterRepository<CustomerEntity> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerListVm>> Handle(GetCustomerListQueryRequest request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAsync();

            return _mapper.Map<List<CustomerListVm>>(customers);
        }
    }
}
