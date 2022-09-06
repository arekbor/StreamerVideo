using Application.Notifications.Common;
using MediatR;

namespace Application.Notifications._ConvertVideo;

public class ConvertVideoNotification
    : INotification
{
    public NotificationLevel NotificationLevel { get; set; }
    public string Message { get; set; }
    public ConvertVideoNotification
        (string message, NotificationLevel notificationLevel)
    {
        Message = message;
        NotificationLevel = notificationLevel;
    }
}