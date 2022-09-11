using Application.Events._ProcessData;
using MediatR;
using NLog;
using NLog.Config;
using VideoLibrary;

namespace Application.Features._ProcessData.Commands;

public class ProcessDataCommandHandler
    : IRequestHandler<ProcessDataCommand, ProcessDataCommandResponse>
{
    public async Task<ProcessDataCommandResponse> Handle(ProcessDataCommand request, CancellationToken cancellationToken)
    {
        var validateResult = await new ProcessDataCommandValidate()
            .ValidateAsync(request, cancellationToken);

        if (!validateResult.IsValid)
            return new ProcessDataCommandResponse(validateResult);

        var processedVideo = YouTube.Default.GetVideoAsync(request.YoutubeUrl);

        _ = processedVideo.ContinueWith(async (task) =>{
            await new ProcessedDataEventHandler().Handle(new ProcessedDataEvent(){
                YouTubeVideo = task.Result
            },cancellationToken);

        },cancellationToken);

        return new ProcessDataCommandResponse();
    }
}