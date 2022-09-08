using Domain.Entities;
using MediatR;

namespace Application.Features._WriteLog;

public class WriteLogCommand
    : IRequest
{
    public string Message { get; set; }
}
