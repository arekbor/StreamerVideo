using Domain.Common;
using MediatR;

namespace Application.Features._WriteLog;

public class WriteLogCommandHandler
    : IRequestHandler<WriteLogCommand, Unit>
{
    public async Task<Unit> Handle(WriteLogCommand request, CancellationToken cancellationToken)
    {
        await Task.Factory.StartNew(() => {
            if (request.NotificationLevel == NotificationLevel.Info) { }
            //logger.LogInformation(request.Message);
            if (request.NotificationLevel == NotificationLevel.Error) { }
            //logger.LogError(request.Message);
        }, cancellationToken);

        return Unit.Value;
    }
}