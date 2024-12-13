using AccountingServer.Domain.Entities;
using AccountingServer.Domain.Events;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TS.Result;

namespace AccountingServer.Application.Features.Auth.SendConfirmEmail;

public sealed class SendConfirmEmailCommandHandler : IRequestHandler<SendConfirmEmailCommand, Result<string>>
{
    private readonly UserManager<AppUser> userManager;
    private readonly IMediator mediator;

    public SendConfirmEmailCommandHandler(UserManager<AppUser>userManager,IMediator mediator)
    {
        this.userManager = userManager;
        this.mediator = mediator;
    }
    public async Task<Result<string>> Handle(SendConfirmEmailCommand request, CancellationToken cancellationToken)
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
        await mediator.Publish(new AppUserEvent(appUser.Id));
        return "Email confirmation sent successfully";
    }
}

