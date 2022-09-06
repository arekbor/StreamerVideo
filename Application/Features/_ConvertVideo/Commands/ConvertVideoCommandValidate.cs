using FluentValidation;

namespace Application.Features.ConvertVideo.Commands;

public class ConvertVideoCommandValidate
    : AbstractValidator<ConvertVideoCommand>
{
    public ConvertVideoCommandValidate()
    {
        RuleFor(x => x.Video.Info.LengthSeconds)
            .LessThan(480)
            .WithMessage("{PropertyName} must be less than {PropertyValue}");

        RuleFor(x => x.PathToSaveVideo)
            .NotEmpty()
            .WithMessage("{PropertyName is required}")
            .NotNull()
            .WithMessage("{PropertyName} cannot be null")
            .Custom((item, context) =>
            {
                if (!Directory.Exists(item))
                {
                    context.AddFailure("The specified path '{PropertyName}' does not exist");
                }
            });
    }
}
