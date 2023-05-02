using BusinessLogic.CQRS.Customers.Queries.GetList;
using Data.Repository.Entities;
using Data.Repository.Interfaces;
using Grpc.Core;
using MediatR;

namespace XmlData.GrpcServices.Services
{
    public class CustomerService : CustomerData.CustomerDataBase
    {
        private readonly IXmlImporterRepository<CustomerEntity> _customerRepository;

        public CustomerService(IXmlImporterRepository<CustomerEntity> customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public override async Task<CustomersResponse> GetCustomers(CustomersRequest request, ServerCallContext context)
        {
            var response = new CustomersResponse();

            var data = await _customerRepository.GetAsync();

            var customers = data.Select(customer => new CustomerListVm 
            {
                Id = customer.Id.ToString(),
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName, 
                ContactTitle = customer.ContactTitle,
                CustomerID = customer.CustomerID,
                //Fax = customer.Fax,
                Phone = customer.Phone,
            }).ToList();

            response.Customers.Add(customers);

            return response;
        }
    }
}
