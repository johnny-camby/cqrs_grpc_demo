using BusinessLogic.CQRS.FullAddresses.Dtos;
using BusinessLogic.Reponses;

namespace BusinessLogic.CQRS.FullAddresses.Commands
{
    public class FullAddressCommandResponse : BaseResponse
    {
        public FullAddressCommandResponse() : base() { }
        public FullAddressDto FullAddressDto { get; set; } = default!;
    }
}
