using Data.Repository.Entities;
using Data.Repository.Interfaces;
using Grpc.Core;

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

        public override async Task<GetCustomerByIdResponse> GetCustomerById(GetCustomerByIdRequest request, ServerCallContext context)
        {
            var customer = await _customerRepository.GetAsync(Guid.Parse(request.CustomerId));
            return new GetCustomerByIdResponse
            {
                Customer = new CustomerGet
                {
                    Id = customer.Id.ToString(),
                    CompanyName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    ContactTitle = customer.ContactTitle,
                    CustomerID = customer.CustomerID,
                    Phone = customer.Phone,
                    //Fax = customer.Fax,
                    Address = customer.FullAddress.Address,
                    City = customer.FullAddress.City,
                    Region = customer.FullAddress.Region,
                    Country = customer.FullAddress.Country,
                    PostalCode = customer.FullAddress.PostalCode
                }
            };
        }

        public override async Task<CreateCustomerResponse> CreateNew(CreateCustomerRequest request, ServerCallContext context)
        {
            var customerEntity = new CustomerEntity
            {
                CustomerID = request.Customer.CustomerID,
                CompanyName = request.Customer.CompanyName,
                ContactName = request.Customer.ContactName,
                ContactTitle = request.Customer.ContactTitle,
                //Fax = request.Customer.Fax,
                Phone = request.Customer.Phone,
                FullAddress = new FullAddressEntity
                {
                    Address = request.Customer.Address,
                    City = request.Customer.City,
                    Country = request.Customer.Country,
                    PostalCode = request.Customer.PostalCode,
                    Region = request.Customer.Region
                }
            };

            var customer = await _customerRepository.AddAsync(customerEntity);

            return new CreateCustomerResponse
            {
                Customer = new CustomerCreate
                {
                    CustomerID = customer.CustomerID,
                    CompanyName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    ContactTitle = customer.ContactTitle,
                    Fax = customer.Fax,
                    Phone = customer.Phone,
                    Address = customer.FullAddress.Address,
                    City = customer.FullAddress.City,
                    Region = customer.FullAddress.Region,
                    PostalCode = customer.FullAddress.PostalCode,
                    Country = customer.FullAddress.Country
                }
            };
        }

        public override async Task<PutCustomerResponse> PutCustomer(PutCustomerRequest request, ServerCallContext context)
        {
            var customer = await _customerRepository.GetAsync(Guid.Parse(request.Customer.Id));

            var customerEntity = new CustomerEntity
            {
                Id = customer.Id,
                CustomerID = request.Customer.CustomerID,
                CompanyName = request.Customer.CompanyName,
                ContactName = request.Customer.ContactName,
                ContactTitle = request.Customer.ContactTitle,
                Fax = request.Customer.Fax,
                Phone = request.Customer.Phone,
                FullAddressId = customer.FullAddressId,
                FullAddress = new FullAddressEntity
                {
                    FullAddressId = customer.FullAddressId,
                    Address = request.Customer.Address,
                    City = request.Customer.City,
                    Country = request.Customer.Country,
                    PostalCode = request.Customer.PostalCode,
                    Region = request.Customer.Region
                }
            };

            await _customerRepository.UpdateAsync(customerEntity);

            return new PutCustomerResponse
            {
                Customer = new CustomerUpdate
                {
                    Id = customerEntity.Id.ToString(),
                    ContactName = customerEntity.ContactName,
                    ContactTitle = customerEntity.ContactTitle,
                    CompanyName = customerEntity.CompanyName,
                    CustomerID = customerEntity.CustomerID,
                    Fax = customerEntity.Fax,
                    Phone = customerEntity.Phone,
                    Address = customerEntity.FullAddress.Address,
                    City = customerEntity.FullAddress.City,
                    Country = customerEntity.FullAddress.Country,
                    PostalCode = customerEntity.FullAddress.PostalCode,
                    Region = customerEntity.FullAddress.Region
                }
            };
        }

        public override async Task<DeleteCustomerResponse> DeleteCustomer(DeleteCustomerRequest request, ServerCallContext context)
        {
            var customer = await _customerRepository.GetAsync(Guid.Parse(request.CustomerId));

            await _customerRepository.DeleteAsync(customer);
            return new DeleteCustomerResponse 
            {};
        }
    }
}
