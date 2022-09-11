using Application.Features._ConvertVideo.Commands;
using Application.Features._Path.Queries;
using Application.Notifications._AppLog;
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

        await new AppLogNotificationHandler().Handle(new AppLogNotification()
        {
            Message = convertResult.ValidationErrors.Any() ? 
                $"Video {notification.YouTubeVideo.Info.Title} {String.Join(", ",convertResult.ValidationErrors)}" : 
                $"Video {notification.YouTubeVideo.Info.Title} converted successfully",

            Level = convertResult.ValidationErrors.Any() ? 
                NLog.LogLevel.Error : 
                NLog.LogLevel.Info,

            Type = typeof(ProcessedDataEventHandler)
        },cancellationToken);
    }
}