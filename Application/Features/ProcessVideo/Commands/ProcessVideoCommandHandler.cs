using MediatR;

namespace Application.Features.ProcessVideo.Commands;

public class ProcessVideoCommandHandler
    : IRequestHandler<ProcessVideoCommand, ProcessVideoCommandResponse>
{
    public Task<ProcessVideoCommandResponse> Handle(ProcessVideoCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}