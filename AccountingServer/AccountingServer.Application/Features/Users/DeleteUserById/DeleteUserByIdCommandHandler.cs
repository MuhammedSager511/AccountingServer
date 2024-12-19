using AccountingServer.Application.Services;
using AccountingServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TS.Result;

namespace AccountingServer.Application.Features.Users.DeleteUserById;

public sealed class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, Result<string>>
{
    private readonly UserManager<AppUser> userManager;
    private readonly ICacheService cacheService;

    public DeleteUserByIdCommandHandler(UserManager<AppUser> userManager, ICacheService cacheService)
    {
        this.userManager = userManager;
        this.cacheService = cacheService;
    }
    public async Task<Result<string>> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
    {
        AppUser? appUser = await userManager.FindByIdAsync(request.Id.ToString());
       
        if (appUser == null)
        {
            return Result<string>.Failure("User not found");
        }

        appUser.isDeleted = true;
        IdentityResult identityResult = await userManager.UpdateAsync(appUser);

        if (!identityResult.Succeeded)
        {
            return Result<string>.Failure(identityResult.Errors.Select(s => s.Description).ToList());
        }
        cacheService.Remove("users");

        return "User deleted successfully";
    }
}
