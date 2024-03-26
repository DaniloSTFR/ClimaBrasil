using ClimaBrasil.Domain.Abstractions;
using ClimaBrasil.Domain.Entities;
using MediatR;

namespace ClimaBrasil.Application.Handlers.CidadesClima.Commands
{
    public class DeleteCidadeClimaCommand : IRequest<CidadeEntity>
    {
        public int Id { get; set; }

        public class DeleteCidadeClimaCommandHandler : IRequestHandler<DeleteCidadeClimaCommand, CidadeEntity>
        {
            private readonly ICidadesClimaRepository _cidadesClimaRepository;

            public DeleteCidadeClimaCommandHandler(ICidadesClimaRepository cidadesClimaRepository)
            {
                _cidadesClimaRepository = cidadesClimaRepository;
            }

            public async Task<CidadeEntity> Handle(DeleteCidadeClimaCommand request, CancellationToken cancellationToken)
            {
                var deletedCiadeClimaInDb  = await _cidadesClimaRepository.DeleteClimaCidade(request.Id);
                return deletedCiadeClimaInDb;
            }
        }

    }
}