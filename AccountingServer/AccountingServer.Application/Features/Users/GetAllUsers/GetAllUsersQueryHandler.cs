using AccountingServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace AccountingServer.Application.Features.Users.GetAllUsers;

public sealed class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Result<List<AppUser>>>
{
    private readonly UserManager<AppUser> userManager;

    public GetAllUsersQueryHandler(UserManager<AppUser>userManager)
    {
        this.userManager = userManager;
    }
    public async Task<Result<List<AppUser>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        List<AppUser> users = await userManager.Users
            .OrderBy(p=>p.FirstName)
            .ToListAsync(cancellationToken);


        return users;
    }
}
