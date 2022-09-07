using Application.Events.ProcessData;
using MediatR;
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

        var processedVideo = await YouTube
            .Default
            .GetVideoAsync(request.YoutubeUrl);

        _ = Task.Run(() => _mediator.Publish(new ProcessedDataEvent()
        { YouTubeVideo = processedVideo }));


        return new ProcessDataCommandResponse();
    }
}