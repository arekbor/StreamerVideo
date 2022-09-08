using MediatR;

namespace Application.Features._ConvertVideo.Commands;

public class ConvertVideoCommandHandler
    : IRequestHandler<ConvertVideoCommand, ConvertVideoCommandResponse>
{
    public async Task<ConvertVideoCommandResponse> Handle(ConvertVideoCommand request, CancellationToken cancellationToken)
    {
        var validateResult = await new ConvertVideoCommandValidate()
            .ValidateAsync(request, cancellationToken);

        if (!validateResult.IsValid)
            return new ConvertVideoCommandResponse(validateResult);

        _ = File.WriteAllBytesAsync
            (Path.Combine(request.PathToSaveVideo, request.Video.FullName), await request.Video.GetBytesAsync(),
            cancellationToken);

        //await Task.Factory.StartNew(async () => {
        //    await File.WriteAllBytesAsync
        //        (Path.Combine(request.PathToSaveVideo, request.Video.FullName), await request.Video.GetBytesAsync());
        //}, cancellationToken);

        return new ConvertVideoCommandResponse();
    }
}