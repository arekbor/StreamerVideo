using Application.Features._ConvertVideo.Commands;
using Application.Features._WriteLog;
using MediatR;

namespace Application.Events._ProcessData;

public class ProcessedDataEventHandler
    : INotificationHandler<ProcessedDataEvent>
{
    public async Task Handle(ProcessedDataEvent notification, CancellationToken cancellationToken)
    {
        await Task.Run(() => {
            var taskConvertVideoCommand = new ConvertVideoCommandHandler().Handle(new ConvertVideoCommand()
            {
                Video = notification.YouTubeVideo,
                PathToSaveVideo = @"F:/pobrane/"
            }, cancellationToken);

            _ = taskConvertVideoCommand.ContinueWith(async (task) =>
            {
                await new WriteLogCommandHandler().Handle(new WriteLogCommand()
                {
                    //TODO send logger message
                }, CancellationToken.None);
            });
        });
    }
}