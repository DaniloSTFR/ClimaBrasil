using ClimaBrasil.Domain.Abstractions;
using ClimaBrasil.Domain.Entities;
using MediatR;

namespace ClimaBrasil.Application.Handlers.CidadesClima.Queries
{
    public class GetAllCidadesClimaQuery : IRequest<IEnumerable<CidadeEntity>>
    {
        public class GetAllCidadesClimaQueryHandler : IRequestHandler<GetAllCidadesClimaQuery, IEnumerable<CidadeEntity>>
        {
            private readonly ICidadesClimaRepository _cidadesClimaRepository;

            public GetAllCidadesClimaQueryHandler(ICidadesClimaRepository cidadesClimaRepository)
            {
                _cidadesClimaRepository = cidadesClimaRepository;
            }

            public async Task<IEnumerable<CidadeEntity>> Handle(GetAllCidadesClimaQuery request, CancellationToken cancellationToken)
            {
                var allCidadesClimaInDb = await _cidadesClimaRepository.GetClimaCidade();
                return allCidadesClimaInDb;
            }
        }

    }
}