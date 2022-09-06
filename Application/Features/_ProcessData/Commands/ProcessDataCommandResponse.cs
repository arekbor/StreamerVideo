using Application.Responses;
using FluentValidation.Results;

namespace Application.Features.ProcessDataFeatures.Commands;

public class ProcessDataCommandResponse
    : BaseResponse
{
    public ProcessDataCommandResponse(ValidationResult validationResult)
        : base(validationResult)
    { }

    public ProcessDataCommandResponse()
    { }
}