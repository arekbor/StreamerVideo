using Application.Features._ConvertVideo.Commands;
using MediatR;

namespace Application.Events._ProcessData;

public class ProcessedDataEventHandler
    : INotificationHandler<ProcessedDataEvent>
{
    public async Task Handle(ProcessedDataEvent notification, CancellationToken cancellationToken)
    {
        var convertResult = await new ConvertVideoCommandHandler().Handle(new ConvertVideoCommand() {
            Video = notification.YouTubeVideo,
            PathToSaveVideo = @"F:/pobrane/"

        }, cancellationToken);
    }
}