using MediatR;

namespace BusinessLogic.CQRS.Customers.Queries.GetList
{
    public class GetCustomerListQueryRequest : IRequest<List<CustomerListVm>>
    {
    }
}
