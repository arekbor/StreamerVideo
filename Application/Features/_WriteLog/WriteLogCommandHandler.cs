using MediatR;

namespace Application.Features._WriteLog;

public class WriteLogCommandHandler
    : IRequestHandler<WriteLogCommand, Unit>
{
    public async Task<Unit> Handle(WriteLogCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine(request.Message);
        return Unit.Value;
    }
}