
using ClimaBrasil.Domain.Abstractions;
using ClimaBrasil.Domain.Entities;
using MediatR;

namespace ClimaBrasil.Application.Handlers.AeroportosClima.Queries
{
    public class GetAllAeroportosClimaQuery : IRequest<IEnumerable<AeroportoEntity>>
    {
        public class GetAllAeroportosClimaQueryHandler : IRequestHandler<GetAllAeroportosClimaQuery, IEnumerable<AeroportoEntity>>
        {
            private readonly IAeroportosClimaRepository _aeroportosClimaRepository;

            public GetAllAeroportosClimaQueryHandler(IAeroportosClimaRepository aeroportosClimaRepository)
            {
                _aeroportosClimaRepository = aeroportosClimaRepository;
            }

            public async Task<IEnumerable<AeroportoEntity>> Handle(GetAllAeroportosClimaQuery request, CancellationToken cancellationToken)
            {
                var allAeroportoClimaInDb = await _aeroportosClimaRepository.GetClimaAeroporto();
                return allAeroportoClimaInDb;
            }
        }

    }
}