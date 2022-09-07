using Domain.Common;

namespace Domain.Entities;

public class Logger
{
    public NotificationLevel NotificationLevel { get; set; }
    public string Message { get; set; }
}
