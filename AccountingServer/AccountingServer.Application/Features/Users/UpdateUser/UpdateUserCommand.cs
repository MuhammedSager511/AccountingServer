using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.Users.UpdateUser;
public sealed record UpdateUserCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string? Password,
    List<Guid> CompanyIds,
    bool IsAdmin
    ) : IRequest<Result<string>>;
