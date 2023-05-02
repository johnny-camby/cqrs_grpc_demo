
using MediatR;

namespace BusinessLogic.CQRS.Customers.Queries.GetDetails
{
    public class GetCustomerDetailQueryRequest : IRequest<CustomerDetailVm>
    {
        public Guid Id { get; set; }
    }
}
