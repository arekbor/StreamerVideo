using Application.Notifications.Common;
using Application.Notifications.Logger;
using MediatR;

namespace Application.Features._ConvertVideo.Commands;

public class ConvertVideoCommandHandler
    : IRequestHandler<ConvertVideoCommand, Unit>
{
    private readonly IMediator _mediator;
    public ConvertVideoCommandHandler(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<Unit> Handle(ConvertVideoCommand request, CancellationToken cancellationToken)
    {
        var validateResult = await new ConvertVideoCommandValidate()
            .ValidateAsync(request, cancellationToken);

        if (!validateResult.IsValid) {
            throw new Exception(String.Join(", ",validateResult.Errors));
        }
        await File.WriteAllBytesAsync
            (Path.Combine(request.PathToSaveVideo, request.Video.FullName), await request.Video.GetBytesAsync());

        //TODO sprwadz czy to nie zatrzyma wątku
        await _mediator.Publish(new LoggerNotification() 
            { Message = $"video {request.Video.Info.Title} saved", NotificationLevel = NotificationLevel.Info })
            .ConfigureAwait(false);

        return Unit.Value;
    }
}