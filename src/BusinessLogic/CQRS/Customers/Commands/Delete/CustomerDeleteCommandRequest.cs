
using MediatR;

namespace BusinessLogic.CQRS.Customers.Commands.Delete
{
    public class CustomerDeleteCommandRequest : IRequest
    {
        public Guid Id { get; set; }
    }
}
