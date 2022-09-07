using Application.Features._ConvertVideo.Commands;
using Application.Notifications._Logger;
using Domain.Common;
using MediatR;

namespace Application.Events.ProcessData;

public class ProcessedDataEventHandler
    : INotificationHandler<ProcessedDataEvent>
{
    private readonly IMediator _mediator;
    public ProcessedDataEventHandler(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task Handle(ProcessedDataEvent notification, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new ConvertVideoCommand()
        { Video = notification.YouTubeVideo, PathToSaveVideo = @"F:/pobrane/" });

        await _mediator.Publish(new LoggerNotification()
        {
            Message = result.ValidationErrors.Any() ?
                $"Error saving video: {String.Join(", ", result.ValidationErrors)}" : "Video successfully saved",

            NotificationLevel = result.ValidationErrors.Any() ?
                NotificationLevel.Error : NotificationLevel.Info
        }, cancellationToken);
    }
}