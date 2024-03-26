using ClimaBrasil.Domain.Abstractions;
using ClimaBrasil.Domain.Entities;
using MediatR;
using ClimaBrasil.Application.BrasilApiRest.DTOs;
using AutoMapper;

namespace ClimaBrasil.Application.Handlers.CidadesClima.Commands
{
    public class CreateCidadeClimaCommand : IRequest<CidadeEntity>
    {
        public CidadeResponse cidadeResponse { get; set; }

        public class CreateCidadeClimaCommandHandler : IRequestHandler<CreateCidadeClimaCommand, CidadeEntity>
        {
            private readonly ICidadesClimaRepository _cidadesClimaRepository;
            private readonly IMapper _mapper;

            public CreateCidadeClimaCommandHandler(ICidadesClimaRepository cidadesClimaRepository, IMapper mapper)
            {
                _cidadesClimaRepository = cidadesClimaRepository;
                _mapper = mapper;
            }

            public async Task<CidadeEntity> Handle(CreateCidadeClimaCommand request, CancellationToken cancellationToken)
            {
                
                var cidade = _mapper.Map<CidadeEntity>(request.cidadeResponse);
                var createdCidadeClimaInDb = await _cidadesClimaRepository.AddClimaCidade(cidade);

                return createdCidadeClimaInDb;
            }

         }
    }
}