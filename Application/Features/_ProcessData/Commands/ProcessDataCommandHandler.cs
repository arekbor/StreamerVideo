using Application.Events.ProcessData;
using MediatR;
using VideoLibrary;

namespace Application.Features.ProcessDataFeatures.Commands;

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

        await _mediator.Publish(new ProcessedDataEvent() 
            { YouTubeVideo = processedVideo });

        return new ProcessDataCommandResponse();
    }
}
//TODO zrob komende do czytania xml, w domain umieszcz xml z pathem, zczytany path wyslij do convertvideocommand