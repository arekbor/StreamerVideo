using Application.Responses;
using FluentValidation.Results;

namespace Application.Features._ConvertVideo.Commands;

public class ConvertVideoCommandResponse
    : BaseResponse
{
    public ConvertVideoCommandResponse(ValidationResult validationResult)
        : base(validationResult) 
    { }

    public ConvertVideoCommandResponse()
    { }
}