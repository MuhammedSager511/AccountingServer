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

namespace AccountingServer.Application.Features.Users.CreateUser;

public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<string>>
{
    private readonly UserManager<AppUser> userManager;
    private readonly IMapper mapper;
    private readonly IMediator mediator;
    private readonly ICompanyUserRepository companyUserRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly ICacheService cacheService;

    public CreateUserCommandHandler(UserManager<AppUser> userManager,
        IMapper mapper,IMediator mediator,
        ICompanyUserRepository companyUserRepository,
        IUnitOfWork unitOfWork,
        ICacheService cacheService
        )
    {
        this.userManager = userManager;
        this.mapper = mapper;
        this.mediator = mediator;
        this.companyUserRepository = companyUserRepository;
        this.unitOfWork = unitOfWork;
        this.cacheService = cacheService;
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

        List<CompanyUser> companyUsers = request.CompanyIds.Select(s => new CompanyUser
        {
            AppUserId = appUser.Id,
            CompanyId = s
        }).ToList();

        await companyUserRepository.AddRangeAsync(companyUsers, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        cacheService.Remove("users");
        //تاكيد ايميل   فيما بعد

        await mediator.Publish(new AppUserEvent(appUser.Id));
        return "Username completed successfully";
    }
}
