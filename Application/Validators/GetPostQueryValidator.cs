
using Cqrs.Users.Service.Application.Models.Request;
using FluentValidation;

namespace Cqrs.Users.Service.Application.Validators;

public class GetPostQueryValidator : AbstractValidator<GetPostRequestModel>
{
    public GetPostQueryValidator()
    {
        RuleFor(v => v.NombreUsuario)
            .NotEmpty()
            .NotNull()
            .WithMessage("Name is null or empty.");
    }
}