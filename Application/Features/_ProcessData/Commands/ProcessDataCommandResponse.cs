using Application.Responses;
using FluentValidation.Results;

namespace Application.Features._ProcessData.Commands;

public class ProcessDataCommandResponse
    : BaseResponse
{
    public ProcessDataCommandResponse(ValidationResult validationResult)
        : base(validationResult)
    { }

    public ProcessDataCommandResponse()
    { }
}