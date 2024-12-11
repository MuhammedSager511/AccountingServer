using AccountingServer.Domain.Entities;
using FluentEmail.Core;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AccountingServer.Domain.Events;

public sealed class SendConfirmEmailEvent : INotificationHandler<AppUserEvent>
{
    private readonly UserManager<AppUser> userManager;
    private readonly IFluentEmail fluentEmail;

    public SendConfirmEmailEvent(UserManager<AppUser>userManager,IFluentEmail fluentEmail)
    {
        this.userManager = userManager;
        this.fluentEmail = fluentEmail;
    }
    public async Task Handle(AppUserEvent notification, CancellationToken cancellationToken)
    {
        AppUser? appUser=await userManager.FindByIdAsync(notification.UserId.ToString());
        if (appUser is not null)
        {
            //اعادة تاكيد ايميل
            await fluentEmail
             .To(appUser.Email)
             .Subject("Email confirmation")
             .Body($@"Confirm your email by clicking on the link below.
                    <a href='http://localhost:4200/confrim-email/{appUser.Email}'
                        target='_blank'>Click to confirm email</a>", true)
             .SendAsync(cancellationToken);

        }
    }
}

