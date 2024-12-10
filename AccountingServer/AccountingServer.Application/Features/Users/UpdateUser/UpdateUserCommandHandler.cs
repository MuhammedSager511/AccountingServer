using AccountingServer.Domain.Entities;
using AutoMapper;

using GenericRepository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace AccountingServer.Application.Features.Users.UpdateUser;

internal sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<string>>
{
    private readonly IMapper mapper;
    private readonly UserManager<AppUser> userManager;

    public UpdateUserCommandHandler(IMapper mapper ,UserManager<AppUser>userManager)
    {
        this.mapper = mapper;
        this.userManager = userManager;
    }

    public async Task<Result<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        AppUser? appUser = await userManager.FindByIdAsync(request.Id.ToString());
        bool isMailChanged= false;
        if(appUser == null)
        {
            return Result<string>.Failure("User not found");
        }

        if(appUser.UserName!=request.UserName)
        {
            bool isUserNameExists = await userManager.Users.AnyAsync(p => p.UserName == request.UserName, cancellationToken);

            if (isUserNameExists)
            {
                return Result<string>.Failure("This username has been used before.");
            }
        }

        if(appUser.Email!=request.Email)
        {
            bool isEmailExists = await userManager.Users.AnyAsync(p => p.Email == request.Email, cancellationToken);

            if (isEmailExists)
            {
                return Result<string>.Failure("This email has been used before.");
            }
            isMailChanged = true;
            appUser.EmailConfirmed = false;
        }

        mapper.Map(request,appUser);
        IdentityResult identityResult= await userManager.UpdateAsync(appUser);

        if (!identityResult.Succeeded)
        {
            return Result<string>.Failure(identityResult.Errors.Select(s => s.Description).ToList());
        }

        string token=  await userManager.GeneratePasswordResetTokenAsync(appUser);
        identityResult=await userManager.ResetPasswordAsync(appUser, token,request.Password);

        if (!identityResult.Succeeded)
        {
            return Result<string>.Failure(identityResult.Errors.Select(s => s.Description).ToList());
        }

        if (isMailChanged)
        {
            //اعادة ارسال تاكيد على ايميل

        }
        return "User updated successfully";
    }
}
