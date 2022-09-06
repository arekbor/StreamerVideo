using Application.Features.ConvertVideo.Commands;
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
    public Task Handle(ProcessedDataEvent notification, CancellationToken cancellationToken)
    {
        _mediator.Send(new ConvertVideoCommand() 
            { Video = notification.YouTubeVideo, PathToSaveVideo = @"F:/pobrane/"});

        return Task.CompletedTask;
    }
}
