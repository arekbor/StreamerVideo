using Application.Events._ProcessData;
using MediatR;
using Moq;
using VideoLibrary;

namespace Application.Features._ProcessData.Commands;

public class ProcessDataCommandHandler
    : IRequestHandler<ProcessDataCommand, ProcessDataCommandResponse>
{
    private readonly IMediator _mediator;
    public ProcessDataCommandHandler(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<ProcessDataCommandResponse> Handle(ProcessDataCommand request, CancellationToken cancellationToken)
    {
        var validateResult = await new ProcessDataCommandValidate()
            .ValidateAsync(request, cancellationToken);

        if (!validateResult.IsValid)
            return new ProcessDataCommandResponse(validateResult);

        var processedVideo = YouTube.Default.GetVideoAsync(request.YoutubeUrl);

        _ = processedVideo.ContinueWith(async (task) =>{
            await _mediator.Send(new ProcessedDataEvent(){
                YouTubeVideo = task.Result
            });
        });

        //await Task.Factory.StartNew(async () =>{
        //    var processedVideo = await YouTube.Default.GetVideoAsync(request.YoutubeUrl);

        //    await new ProcessedDataEventHandler().Handle(new ProcessedDataEvent()
        //    {
        //        YouTubeVideo = processedVideo
        //    }, CancellationToken.None);

        //}, cancellationToken);

        return new ProcessDataCommandResponse();
    }
}