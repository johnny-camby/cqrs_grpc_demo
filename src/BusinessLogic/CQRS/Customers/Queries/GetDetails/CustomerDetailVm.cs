
using BusinessLogic.CQRS.FullAddresses.Dtos;

namespace BusinessLogic.CQRS.Customers.Queries.GetDetails
{
    public class CustomerDetailVm
    {
        public Guid Id { get; set; }
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public Guid FullAddressId { get; set; }
        //public FullAddressDto FullAddress { get; set; } = default!;

        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
    }
}
