using FluentValidation;
using URLShortener.Models;


namespace URLShortener.Validation
{
    public class UrlDtoValidator : AbstractValidator<UrlDto>
    {
        public UrlDtoValidator()
        {
            RuleFor(x => x.Url).NotNull().WithMessage("{PropertyName}, is required").NotEmpty().WithMessage("{PropertyName}, is required!");
        }
    }
}
