using Data.Repository.Entities;
using MediatR;

namespace BusinessLogic.CQRS.FullAddresses.Commands
{
    public class FullAddressCommandRequest : IRequest<FullAddressCommandResponse>
    {
        public string Address { get; set; }
        public FullAddressEntity FullAddress { get; set; }
    }
}
