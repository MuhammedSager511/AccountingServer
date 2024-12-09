using FluentValidation;

namespace AccountingServer.Application.Features.Auth.Login
{
    public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(p => p.EmailOrUserName)
                .MinimumLength(3)
                .WithMessage("Username or e-mail information must be at least 3 characters");
            RuleFor(p => p.Password)
                .MinimumLength(1)
                .WithMessage("The password must be at least 1 character");
        }
    }
}
