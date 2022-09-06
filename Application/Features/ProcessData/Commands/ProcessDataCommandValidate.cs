using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.Features.ProcessData.Commands;

public class ProcessDataCommandValidate
    : AbstractValidator<ProcessDataCommand>
{
    public ProcessDataCommandValidate()
    {
        RuleFor(x => x.Rank)
            .NotEmpty()
            .WithMessage("{PropertyName is required}")
            .NotNull()
            .WithMessage("{PropertyName} cannot be null")
            .Must(BeNumeric)
            .WithMessage("{PropertyName} cannot contains alphabetic symbols")
            .Custom((item, context) =>{
                var rank = int.Parse(item);
                if (rank < 1 || rank > 12) {
                    context.AddFailure("{PropertyName} must be greater than 0 and less than 13");
                }
            });

        RuleFor(x => x.Token)
            .NotEmpty()
            .WithMessage("{PropertyName is required}")
            .NotNull()
            .WithMessage("{PropertyName} cannot be null")
            .Must(BeNumeric)
            .WithMessage("{PropertyName} cannot contains alphabetic symbols")
            .MaximumLength(20)
            .WithMessage("{PropertyName} must not exteed 20 characters");

        RuleFor(x => x.SteamId)
            .NotEmpty()
            .WithMessage("{PropertyName is required}")
            .NotNull()
            .WithMessage("{PropertyName} cannot be null")
            .Must(BeNumeric)
            .WithMessage("{PropertyName} cannot contains alphabetic symbols")
            .MaximumLength(20)
            .WithMessage("{PropertyName} must not exteed 20 characters");

        RuleFor(x => x.YoutubeUrl)
            .NotEmpty()
            .WithMessage("{PropertyName is required")
            .NotNull()
            .WithMessage("{PropertyName} cannot be null")
            .Must(BeWellFormatedUri)
            .WithMessage("{PropertyName} must be a valid url");

        RuleFor(x => x.PathToSaveVideo)
            .NotEmpty()
            .WithMessage("{PropertyName is required}")
            .NotNull()
            .WithMessage("{PropertyName} cannot be null")
            .Custom((item, context) => {
                if (!Directory.Exists(item)) {
                    context.AddFailure("The specified path '{PropertyName}' does not exist");
                }
            });
    }
    private bool BeNumeric(string property)
    {
        if (!Regex.IsMatch(property, @"^-?\d*\.{0,1}\d+$")) return false;
        return true;
    }
    private bool BeWellFormatedUri(string property)
    {
        if (!Uri.IsWellFormedUriString(property, UriKind.Absolute)) return false;
        return true;
    }
}
