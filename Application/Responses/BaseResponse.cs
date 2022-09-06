using FluentValidation.Results;

namespace Application.Responses;

public class BaseResponse
{
    public List<string> ValidationErrors { get; set; }
    public BaseResponse(ValidationResult validationResult)
    {
        ValidationErrors = new List<string>();
        ValidationErrors.AddRange(
            validationResult.Errors.Select(x => x.ErrorMessage).AsEnumerable());
    }
}
