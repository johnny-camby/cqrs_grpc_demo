using AutoMapper;
using BusinessLogic.CQRS.FullAddresses.Dtos;
using Data.Repository.Entities;
using Data.Repository.Interfaces;
using MediatR;

namespace BusinessLogic.CQRS.FullAddresses.Commands
{
    public class FullAddressCommandHandler : IRequestHandler<FullAddressCommandRequest, FullAddressCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IXmlImporterRepository<FullAddressEntity> _fullAddressRepository;

        public FullAddressCommandHandler(IMapper mapper,
            IXmlImporterRepository<FullAddressEntity> fullAddressRepository)
        {
            _mapper = mapper;
            _fullAddressRepository = fullAddressRepository;
        }
        public async Task<FullAddressCommandResponse> Handle(FullAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var fullAddressCmdResponse = new FullAddressCommandResponse();

            if (fullAddressCmdResponse.Success)
            {
                var fullAddress = new FullAddressEntity { Address = request.Address };
                fullAddress = await _fullAddressRepository.AddAsync(fullAddress);
                fullAddressCmdResponse.FullAddressDto = _mapper.Map<FullAddressDto>(fullAddress);
            }
            return fullAddressCmdResponse;
        }
    }
}
