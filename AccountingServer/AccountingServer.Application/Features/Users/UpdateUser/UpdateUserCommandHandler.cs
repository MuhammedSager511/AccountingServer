using AccountingServer.Application.Services;
using AccountingServer.Domain.Entities;
using AccountingServer.Domain.Events;
using AccountingServer.Domain.Repositories;
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
    private readonly IMediator mediator;
    private readonly ICompanyUserRepository companyUserRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly ICacheService cacheService;

    public UpdateUserCommandHandler(IMapper mapper ,UserManager<AppUser>userManager, 
        IMediator mediator, ICompanyUserRepository companyUserRepository,
        IUnitOfWork unitOfWork, ICacheService cacheService)
    {
        this.mapper = mapper;
        this.userManager = userManager;
        this.mediator = mediator;
        this.companyUserRepository = companyUserRepository;
        this.unitOfWork = unitOfWork;
        this.cacheService = cacheService;
    }

    public async Task<Result<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        AppUser? appUser = await userManager.Users
            .Where(p => p.Id == request.Id)
            .Include(p => p.CompanyUsers)
            .FirstOrDefaultAsync(cancellationToken);


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

        if(request.Password is not null)
        {
            string token = await userManager.GeneratePasswordResetTokenAsync(appUser);
            identityResult = await userManager.ResetPasswordAsync(appUser, token, request.Password);

            if (!identityResult.Succeeded)
            {
                return Result<string>.Failure(identityResult.Errors.Select(s => s.Description).ToList());
            }
        }
        companyUserRepository.DeleteRange(appUser.CompanyUsers);

        List<CompanyUser> companyUsers = request.CompanyIds.Select(s => new CompanyUser
        {
            AppUserId = appUser.Id,
            CompanyId = s
        }).ToList();

        await companyUserRepository.AddRangeAsync(companyUsers, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

          cacheService.Remove("users");

        if (isMailChanged)
        {
            //اعادة ارسال تاكيد على ايميل
            await mediator.Publish(new AppUserEvent(appUser.Id));
        }
        return "User updated successfully";
    }
}
