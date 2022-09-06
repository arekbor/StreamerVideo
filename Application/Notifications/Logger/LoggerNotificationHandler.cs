using Application.Notifications.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Notifications._ConvertVideo;

public class ConvertVideoNotificationHandler
    : INotificationHandler<ConvertVideoNotification>
{
    private readonly ILogger _logger;
    public ConvertVideoNotificationHandler(ILogger logger)
    {
        _logger = logger;
    }
    public Task Handle(ConvertVideoNotification notification, CancellationToken cancellationToken)
    {
        if (notification.NotificationLevel == NotificationLevel.Info) {
            _logger.LogInformation(notification.Message);
        }
        if (notification.NotificationLevel == NotificationLevel.Error) {
            _logger.LogError(notification.Message);
        }
        return Task.CompletedTask;
    }
}