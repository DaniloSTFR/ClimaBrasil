using ClimaBrasil.Domain.Abstractions;
using ClimaBrasil.Domain.Entities;
using MediatR;

namespace ClimaBrasil.Application.Handlers.AeroportosClima.Queries
{
    public class GetAeroportoClimaByIdQuery : IRequest<AeroportoEntity>
    {
        public int Id { get; set; }

        public class GetAeroportoClimaByIdQueryHandler  : IRequestHandler<GetAeroportoClimaByIdQuery, AeroportoEntity>
        {
            private readonly IAeroportosClimaRepository _aeroportosClimaRepository;

            public GetAeroportoClimaByIdQueryHandler(IAeroportosClimaRepository aeroportosClimaRepository)
            {
                _aeroportosClimaRepository = aeroportosClimaRepository;
            }

            public async Task<AeroportoEntity> Handle(GetAeroportoClimaByIdQuery request, CancellationToken cancellationToken)
            {
                var aeroportoClimaInDb = await _aeroportosClimaRepository.GetClimaAeroportoById(request.Id);
                return aeroportoClimaInDb;
            }
        }
        
    }
}