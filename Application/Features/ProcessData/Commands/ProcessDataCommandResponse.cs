using Application.Responses;
using FluentValidation.Results;

namespace Application.Features.ProcessData.Commands;

public class ProcessDataCommandResponse
    : BaseResponse
{
    public string Token { get; set; }
    public ProcessDataCommandResponse(ValidationResult validationResult)
        : base(validationResult)
    { }
    public ProcessDataCommandResponse(string token)
    {
        Token = token;
    }
}