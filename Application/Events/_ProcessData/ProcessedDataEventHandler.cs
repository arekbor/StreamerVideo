using Application.Features._ConvertVideo.Commands;
using Application.Features._WriteLog;
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

        await new WriteLogCommandHandler().Handle(new WriteLogCommand()
        {
            Message = convertResult.ValidationErrors.Any() ? 
                $"Video error list: {String.Join(",", convertResult.ValidationErrors)}" :
                $"Video converted successfuly"

        }, cancellationToken);
    }
}