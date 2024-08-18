using Cqrs.Users.Service.Application.Models.Request;
using FluentValidation;

namespace Cqrs.Users.Service.Application.Validators;

public class AddPostCommandValidator : AbstractValidator<AddPostRequestModel>
{
    public AddPostCommandValidator()
    {
        RuleFor(v => v.CorreoElectronico)
            .MaximumLength(200)
            .NotEmpty()
            .WithMessage("email is empty.");

        RuleFor(v => v.NombreUsuario)
            .MaximumLength(1000)
            .NotEmpty()
            .WithMessage("Name is empty.");


        RuleFor(v => v.Contrasena)
            .NotNull()
            .NotEmpty()
            .WithMessage("Password is empty.");
    }
}