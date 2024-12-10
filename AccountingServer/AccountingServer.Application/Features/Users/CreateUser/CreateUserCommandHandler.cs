using AccountingServer.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace AccountingServer.Application.Features.Users.CreateUser;

public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<string>>
{
    private readonly UserManager<AppUser> userManager;
    private readonly IMapper mapper;

    public CreateUserCommandHandler(UserManager<AppUser> userManager,IMapper mapper)
    {
        this.userManager = userManager;
        this.mapper = mapper;
    }
    public async Task<Result<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        bool isUserNameExists=await userManager.Users.AnyAsync(p=>p.UserName == request.UserName,cancellationToken);
    
        if (isUserNameExists)
        {
            return Result<string>.Failure("This username has been used before.");
        }



        bool isEmailExists = await userManager.Users.AnyAsync(p => p.Email == request.Email, cancellationToken);
      
        if (isEmailExists)
        {
            return Result<string>.Failure("This email has been used before.");
        }

        AppUser appUser = mapper.Map<AppUser>(request);

       IdentityResult identityResult= await userManager.CreateAsync(appUser,request.Password);

        if(!identityResult.Succeeded)
        {
            return Result<string>.Failure(identityResult.Errors.Select(s => s.Description).ToList());
        }

        //تاكيد ايميل   فيما بعد

        return "Username completed successfully";
    }
}
