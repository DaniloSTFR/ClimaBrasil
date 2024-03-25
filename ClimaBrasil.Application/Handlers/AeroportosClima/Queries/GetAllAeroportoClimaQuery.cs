
using ClimaBrasil.Domain.Abstractions;
using ClimaBrasil.Domain.Entities;
using MediatR;

namespace ClimaBrasil.Application.Handlers.AeroportosClima.Queries
{
    public class GetAllAeroportoClimaQuery : IRequest<IEnumerable<AeroportoEntity>>
    {
        public class GetMembersQueryHandler : IRequestHandler<GetAllAeroportoClimaQuery, IEnumerable<AeroportoEntity>>
        {
            private readonly IAeroportosClimaRepository _aeroportosClimaRepository;

            public GetMembersQueryHandler(IAeroportosClimaRepository aeroportosClimaRepository)
            {
                _aeroportosClimaRepository = aeroportosClimaRepository;
            }

            public async Task<IEnumerable<AeroportoEntity>> Handle(GetAllAeroportoClimaQuery request, CancellationToken cancellationToken)
            {
                var allAeroportoClimaInDb = await _aeroportosClimaRepository.GetClimaAeroporto();
                return allAeroportoClimaInDb;
            }
        }

    }
}