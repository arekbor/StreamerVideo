using Application.Features._ConvertVideo.Commands;
using Application.Features._Path.Queries;
using MediatR;

namespace Application.Events._ProcessData;

public class ProcessedDataEventHandler
    : INotificationHandler<ProcessedDataEvent>
{
    public async Task Handle(ProcessedDataEvent notification, CancellationToken cancellationToken)
    {
        var pathToSaveVideoResult = await new GetPathToConvertVideoQueryHandler()
            .Handle(new GetPathToConvertVideoQuery(),cancellationToken);

        var convertResult = await new ConvertVideoCommandHandler().Handle(new ConvertVideoCommand() {
            Video = notification.YouTubeVideo,
            PathToSaveVideo = pathToSaveVideoResult

        }, cancellationToken);
    }
}