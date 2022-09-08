using Application.Features._ConvertVideo.Commands;
using Application.Features._WriteLog;
using MediatR;

namespace Application.Events._ProcessData;

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
        var resultTask = _mediator.Send(new ConvertVideoCommand() {
            Video = notification.YouTubeVideo,
            PathToSaveVideo = @"F:/pobrane/"

        }, cancellationToken);

        _ = resultTask.ContinueWith(async (task) => {

            await _mediator.Send(new WriteLogCommand() {
                Message = "message test"
            });
        });

        //await Task.Run(() => {
        //    var taskConvertVideoCommand = new ConvertVideoCommandHandler().Handle(new ConvertVideoCommand()
        //    {
        //        Video = notification.YouTubeVideo,
        //        PathToSaveVideo = @"F:/pobrane/"
        //    }, cancellationToken);

        //    _ = taskConvertVideoCommand.ContinueWith(async (task) =>
        //    {
        //        await new WriteLogCommandHandler().Handle(new WriteLogCommand()
        //        {
        //            //TODO send logger message
        //        }, CancellationToken.None);
        //    });
        //});
    }
}