using Domain.Models;
using MediatR;
using NLog;

namespace Application.Notifications._AppLog;

public class AppLogNotification
    : AppLog<LogLevel>, INotification
{ }