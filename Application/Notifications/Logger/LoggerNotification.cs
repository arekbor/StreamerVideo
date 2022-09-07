using Application.Notifications.Common;
using MediatR;

namespace Application.Notifications.Logger;

public class LoggerNotification
    : INotification
{
    public NotificationLevel NotificationLevel { get; set; }
    public string Message { get; set; }
    public LoggerNotification
        (string message, NotificationLevel notificationLevel)
    {
        Message = message;
        NotificationLevel = notificationLevel;
    }
    public LoggerNotification()
    {
    }
}