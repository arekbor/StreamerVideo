using MediatR;

namespace Application.Features.ProcessData.Commands;

public class ProcessDataCommandHandler
    : IRequestHandler<ProcessDataCommand, ProcessDataCommandResponse>
{
    public async Task<ProcessDataCommandResponse> Handle(ProcessDataCommand request, CancellationToken cancellationToken)
    {
        var validateResult = await new ProcessDataCommandValidate()
            .ValidateAsync(request, cancellationToken);

        if (!validateResult.IsValid)
            return new ProcessDataCommandResponse(validateResult);

        return new ProcessDataCommandResponse(request.Token);
    }
}