using ClimaBrasil.Domain.Abstractions;
using ClimaBrasil.Domain.Entities;
using MediatR;
using ClimaBrasil.Application.BrasilApiRest.DTOs;
using AutoMapper;

namespace ClimaBrasil.Application.Handlers.AeroportosClima.Commands
{
    public class CreateAeroportoClimaCommand : IRequest<AeroportoEntity>
    {
        public AeroportoResponse aeroportoResponse { get; set; }

        public class CreateAeroportoClimaCommandHandler : IRequestHandler<CreateAeroportoClimaCommand, AeroportoEntity>
        {
            private readonly IAeroportosClimaRepository _aeroportosClimaRepository;
            private readonly IMapper _mapper;

            public CreateAeroportoClimaCommandHandler(IAeroportosClimaRepository aeroportosClimaRepository, IMapper mapper)
            {
                _aeroportosClimaRepository = aeroportosClimaRepository;
                _mapper = mapper;
            }

            public async Task<AeroportoEntity> Handle(CreateAeroportoClimaCommand request, CancellationToken cancellationToken)
            {
                var aeroporto = _mapper.Map<AeroportoEntity>(request.aeroportoResponse);
                var createdAeroportoClimaInDb = await _aeroportosClimaRepository.AddClimaAeroporto(aeroporto);

                return createdAeroportoClimaInDb;
            }
        }

    }
}