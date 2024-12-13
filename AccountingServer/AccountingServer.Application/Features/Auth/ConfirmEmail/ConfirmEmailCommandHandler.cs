using AccountingServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TS.Result;

namespace AccountingServer.Application.Features.Auth.ConfirmEmail;

public sealed class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, Result<string>>
{
    private readonly UserManager<AppUser> userManager;

    public ConfirmEmailCommandHandler(UserManager<AppUser> userManager)
    {
        this.userManager = userManager;
    }
    public async Task<Result<string>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        AppUser? appUser = await userManager.FindByEmailAsync(request.email);
        if (appUser == null)
        {
            return "Your email is not registered in the system";
        }
        if (appUser.EmailConfirmed)
        {
            return "Confirmed Email";
        }
        appUser.EmailConfirmed = true;
        await userManager.UpdateAsync(appUser);
        return "Email confirmed successfully";
    }
}
