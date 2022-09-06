using Application.Responses;
using FluentValidation.Results;

namespace Application.Features.ProcessVideo.Commands;

public class ProcessVideoCommandResponse
    : BaseResponse
{
    public string Token { get; set; }
    public ProcessVideoCommandResponse(ValidationResult validationResult)
        : base(validationResult)
    { }
    public ProcessVideoCommandResponse(string token)
    {
        Token = token;
    }
}