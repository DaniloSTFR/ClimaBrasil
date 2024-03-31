using ClimaBrasil.Domain.Abstractions;
using ClimaBrasil.Domain.Entities;
using MediatR;
using AutoMapper;

namespace ClimaBrasil.Application.Handlers.ErrorLogs.Commands
{
    public class ErrorLogsCommand : IRequest<ErrorLogsEntity>
    {

        public int StatusCode { get; set; }
        public string ErrorMessage {get; set;}
        public string RotaControllerRequest {get; set;}

        public class ErrorLogsCommandHandler : IRequestHandler<ErrorLogsCommand, ErrorLogsEntity>
        {
            private readonly IErrorLogsRepository _errorLogsRepository;

            public ErrorLogsCommandHandler(IErrorLogsRepository errorLogsRepository)
            {
                _errorLogsRepository = errorLogsRepository;
            }

            public async Task<ErrorLogsEntity> Handle(ErrorLogsCommand request, CancellationToken cancellationToken)
            {
                var error = new ErrorLogsEntity(request.StatusCode, request.ErrorMessage, request.RotaControllerRequest);
                var newError = await _errorLogsRepository.AddErrorLogs(error);

                return newError;
            }
        }

    }
}