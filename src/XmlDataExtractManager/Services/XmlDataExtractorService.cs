
using Data.Repository.Entities;
using Data.Repository.Interfaces;
using System.Xml.Serialization;
using XmlDataExtractManager.Interfaces;

namespace XmlDataExtractManager.Services
{
    public class XmlDataExtractorService : IXmlDataExtractorService
    {
        private readonly IXmlImporterRepository<CustomerEntity> _customerRepository;
        private readonly IXmlImporterRepository<FullAddressEntity> _fullAddressRepository;
        private readonly IXmlImporterRepository<OrderEntity> _orderRepository;
        private readonly IXmlImporterRepository<ShipInfoEntity> _shipInfoRepository;

        public XmlDataExtractorService(IXmlImporterRepository<CustomerEntity> customerRepository,
            IXmlImporterRepository<FullAddressEntity> fullAddressRepository,
            IXmlImporterRepository<OrderEntity> orderRepository,
            IXmlImporterRepository<ShipInfoEntity> shipInfoRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _fullAddressRepository = fullAddressRepository ?? throw new ArgumentNullException(nameof(fullAddressRepository));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _shipInfoRepository = shipInfoRepository ?? throw new ArgumentNullException(nameof(shipInfoRepository));
        }

        public T Deserialize<T>(string input) where T : class
        {
            XmlSerializer serializer = new(typeof(T));

            using StringReader sr = new(input);
            return (T)serializer.Deserialize(sr);
        }

        public async Task ProcessXmlAsync(string xmlfile)
        {
            try
            {
                var xmlInputData = File.ReadAllText(xmlfile);
                var rootData = Deserialize<Root>(xmlInputData);
                await ExtractCustomersAsync(rootData);
                await ExtractOrdersAsync(rootData);
            }
            catch (Exception ex)
            {

            }
        }

        private async Task ExtractOrdersAsync(Root rootData)
        {
            foreach (var order in rootData.Orders.Order)
            {
                var orderEntity = new OrderEntity
                {
                    CustomerID = order.CustomerID,
                    EmployeeID = order.EmployeeID,
                    OrderDate = order.OrderDate,
                    RequiredDate = order.RequiredDate,
                    ShipInfo = new ShipInfoEntity
                    {
                        ShippedDate = order.ShipInfo.ShippedDate,
                        Freight = order.ShipInfo.Freight,
                        ShipAddress = order.ShipInfo.ShipAddress,
                        ShipCity = order.ShipInfo.ShipCity,
                        ShipCountry = order.ShipInfo.ShipCountry,
                        ShipName = order.ShipInfo.ShipName,
                        ShipPostalCode = order.ShipInfo.ShipPostalCode,
                        ShipRegion = order.ShipInfo.ShipRegion,
                        ShipVia = order.ShipInfo.ShipVia
                    }
                };
                await _shipInfoRepository.AddAsync(orderEntity.ShipInfo);
                await _orderRepository.AddAsync(orderEntity);
            }
        }

        private async Task ExtractCustomersAsync(Root rootData)
        {
            foreach (var customer in rootData.Customers.Customer)
            {
                var customerEntity = new CustomerEntity
                {
                    CustomerID = customer.CustomerID,
                    CompanyName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    ContactTitle = customer.ContactTitle,
                    Phone = customer.Phone,
                    Fax = customer.Fax,

                    FullAddress = new FullAddressEntity
                    {
                        Address = customer.FullAddress.Address,
                        City = customer.FullAddress.City,
                        Region = customer.FullAddress.Region,
                        PostalCode = customer.FullAddress.PostalCode,
                        Country = customer.FullAddress.Country
                    }
                };
                await _fullAddressRepository.AddAsync(customerEntity.FullAddress);
                await _customerRepository.AddAsync(customerEntity);
            }
        }
    }


}
