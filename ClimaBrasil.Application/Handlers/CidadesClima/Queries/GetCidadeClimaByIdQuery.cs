using ClimaBrasil.Domain.Abstractions;
using ClimaBrasil.Domain.Entities;
using MediatR;

namespace ClimaBrasil.Application.Handlers.CidadesClima.Queries
{
    public class GetCidadeClimaByIdQuery : IRequest<CidadeEntity>
    {
        public int Id { get; set; }

        public class GetCidadeClimaByIdQueryHandler : IRequestHandler<GetCidadeClimaByIdQuery, CidadeEntity>
        {
            private readonly ICidadesClimaRepository _cidadesClimaRepository;

            public GetCidadeClimaByIdQueryHandler(ICidadesClimaRepository cidadesClimaRepository)
            {
                _cidadesClimaRepository = cidadesClimaRepository;
            }

            public async Task<CidadeEntity> Handle(GetCidadeClimaByIdQuery request, CancellationToken cancellationToken)
            {
                var allCidadeClimaInDb = await _cidadesClimaRepository.GetClimaCidadeById(request.Id);
                return allCidadeClimaInDb;
            }
        }

    }
}