using MediatR;

namespace Application.Notifications._AppLog;

public class AppLogNotificationHandler
    : INotificationHandler<AppLogNotification>
{
    public async Task Handle(AppLogNotification notification, CancellationToken cancellationToken)
    {
        await Task.Run(() => {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Log(notification.Level, $"{notification.Type} | {notification.Message}");
        },cancellationToken);
    }
}