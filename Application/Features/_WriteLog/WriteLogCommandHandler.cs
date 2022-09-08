using MediatR;

namespace Application.Features._WriteLog;

public class WriteLogCommandHandler
    : IRequestHandler<WriteLogCommand, Unit>
{
    public async Task<Unit> Handle(WriteLogCommand request, CancellationToken cancellationToken)
    {
        await Task.Factory.StartNew(() => {
            //TODO do logger logic
        }, cancellationToken);

        return Unit.Value;
    }
}