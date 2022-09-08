using Domain.Entities;
using MediatR;

namespace Application.Features._WriteLog;

public class WriteLogCommand
    : Logger, IRequest
{

}
