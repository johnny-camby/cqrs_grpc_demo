
using Data.Repository.Entities;
using Data.Repository.Interfaces;
using Grpc.Core;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Authorization;
using XmlDataExtractManager.Interfaces;
using static XmlData.GrpcServices.CustomerData;

namespace XmlData.GrpcServices.Services
{
    [Authorize(AuthenticationSchemes = CertificateAuthenticationDefaults.AuthenticationScheme)]
    public class CustomerService : CustomerDataBase
    {
        private readonly IXmlImporterRepository<CustomerEntity> _customerRepository;
        private readonly IXmlDataExtractorService _xmlDataExtractorService;
        private readonly IConfiguration _config;

        public CustomerService(IXmlImporterRepository<CustomerEntity> customerRepository,
            IXmlDataExtractorService xmlDataExtractorService
            , IConfiguration config)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _xmlDataExtractorService = xmlDataExtractorService ?? throw new ArgumentNullException(nameof(xmlDataExtractorService));
            _config = config ?? throw new ArgumentNullException(nameof(config));
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
                Fax = customer.Fax,
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
                    Fax = customer.Fax,
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
                Fax = request.Customer.Fax,
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
            { };
        }

        public override async Task<UploadXmlResponse> UploadXml(IAsyncStreamReader<UploadXmlRequest> requestStream, ServerCallContext context)
        {
            var data = new List<byte>();

            await foreach(var message in requestStream.ReadAllAsync())
            {
                if (message.Metadata != null)
                {
                    await _xmlDataExtractorService.ProcessXmlAsync(message.Metadata.FilePath);
                }

            }

            while (await requestStream.MoveNext())
            {
                data.AddRange(requestStream.Current.Data);

                if (data.Any())
                {
                    await _xmlDataExtractorService.ProcessXmlAsync(requestStream.Current.Metadata.FilePath);
                }
            }

            // using FileStream writeStream = await ProcessStream(requestStream);

            return new UploadXmlResponse { IsOk = true };
        }

        private async Task<FileStream> ProcessStream(IAsyncStreamReader<UploadXmlRequest> requestStream)
        {
            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles"));
            //var uploadId = Path.GetRandomFileName();
            //string path = Path.Combine(_config["StoredFilesPath"]!, uploadId);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var filePath = Path.Combine(path, "metadata.json");
            var writeStream = File.Create(Path.Combine(path, "data.bin"));

            var dv = requestStream.ReadAllAsync();

            await foreach (var message in requestStream.ReadAllAsync())
            {
                if (message.Metadata != null)
                {
                    await File.WriteAllTextAsync(filePath, message.Metadata.ToString());
                }

                if (message.Data != null)
                {
                    await writeStream.WriteAsync(message.Data.Memory);
                }
            }

            await _xmlDataExtractorService.ProcessXmlAsync(path);
            return writeStream;
        }
    }
}
