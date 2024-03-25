using ClimaBrasil.Domain.Abstractions;
using ClimaBrasil.Domain.Entities;
using MediatR;

namespace ClimaBrasil.Application.Handlers.AeroportosClima.Commands
{
    public class DeleteAeroportoClimaCommand : IRequest<AeroportoEntity>
    {
        public int Id { get; set; }
        public class DeleteAeroportoClimaCommandHandler : IRequestHandler<DeleteAeroportoClimaCommand, AeroportoEntity>
        {
            private readonly IAeroportosClimaRepository _aeroportosClimaRepository;

            public DeleteAeroportoClimaCommandHandler(IAeroportosClimaRepository aeroportosClimaRepository)
            {
                _aeroportosClimaRepository = aeroportosClimaRepository;
            }

            public async Task<AeroportoEntity> Handle(DeleteAeroportoClimaCommand request, CancellationToken cancellationToken)
            {
                var deletedAeroportoClimaInDb = await _aeroportosClimaRepository.DeleteClimaAeroporto(request.Id);
                return deletedAeroportoClimaInDb;
            }
        }
        
    }
}