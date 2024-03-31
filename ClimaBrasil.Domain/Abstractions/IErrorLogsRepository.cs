using System.Runtime.CompilerServices;
using ClimaBrasil.Domain.Entities;

namespace ClimaBrasil.Domain.Abstractions
{
    public interface IErrorLogsRepository
    {
        Task<ErrorLogsEntity> AddErrorLogs(ErrorLogsEntity errorLogs);
        
    }
}