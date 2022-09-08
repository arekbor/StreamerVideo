using Application.Features._ConvertVideo.Commands;
using Application.Features._WriteLog;
using Domain.Common;
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
                    Message = task.Result.ValidationErrors.Any() ?
                    $"Error saving video: {String.Join(", ", task.Result.ValidationErrors)}" : "Video successfully saved",

                    NotificationLevel = task.Result.ValidationErrors.Any() ?
                                NotificationLevel.Error : NotificationLevel.Info
                }, CancellationToken.None);
            });
        });
    }
}