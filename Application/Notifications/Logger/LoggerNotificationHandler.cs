using Application.Notifications.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Notifications.Logger;

public class LoggerNotificationHandler
    : INotificationHandler<LoggerNotification>
{
    private readonly ILogger<LoggerNotificationHandler> _logger;
    public LoggerNotificationHandler(ILogger<LoggerNotificationHandler> logger)
    {
        _logger = logger;
    }
    public Task Handle(LoggerNotification notification, CancellationToken cancellationToken)
    {
        Task.Delay(5000).GetAwaiter().GetResult();
        if (notification.NotificationLevel == NotificationLevel.Info) {
            _logger.LogInformation(notification.Message);
        }
        if (notification.NotificationLevel == NotificationLevel.Error) {
            _logger.LogError(notification.Message);
        }
        return Task.CompletedTask;
    }
}