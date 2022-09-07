using Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Notifications._Logger;

//public class LoggerNotificationHandler
//    : INotificationHandler<LoggerNotification>
//{
//    private readonly ILogger<LoggerNotification> _logger;
//    public LoggerNotificationHandler(ILogger<LoggerNotification> logger)
//    {
//        _logger = logger;
//    }
//    public Task Handle(LoggerNotification notification, CancellationToken cancellationToken)
//    {
//        if (notification.NotificationLevel == NotificationLevel.Info) {
//            _logger.LogInformation(notification.Message);
//        }
//        if (notification.NotificationLevel == NotificationLevel.Error) {
//            _logger.LogError(notification.Message);
//        }
//        return Task.CompletedTask;
//    }
//}
public class LoggerNotificationHandler
    : INotificationHandler<LoggerNotification>
{
    public Task Handle(LoggerNotification notification, CancellationToken cancellationToken)
    {
        if (notification.NotificationLevel == NotificationLevel.Info)
        {
            Console.WriteLine();
        }
        if (notification.NotificationLevel == NotificationLevel.Error)
        {
            Console.WriteLine();
        }
        return Task.CompletedTask;
    }
}