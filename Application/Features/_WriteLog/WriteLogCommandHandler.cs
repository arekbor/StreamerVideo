using Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features._WriteLog;

public class WriteLogCommandHandler
    : IRequestHandler<WriteLogCommand, Unit>
{
    private readonly ILogger<WriteLogCommand> _logger;
    public WriteLogCommandHandler(ILogger<WriteLogCommand> logger)
    {
        _logger = logger;
    }
    public Task<Unit> Handle(WriteLogCommand request, CancellationToken cancellationToken)
    {
        if(request.NotificationLevel == NotificationLevel.Info)
            _logger.LogInformation(request.Message);
        if (request.NotificationLevel == NotificationLevel.Error)
            _logger.LogError(request.Message);

        return Task.FromResult(Unit.Value);
    }
}