using AccountingServer.Application.Features.Auth.Login;
using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.Auth.ChangeCompany;
public sealed record ChangeCompanyCommand(Guid CompanyId) : IRequest<Result<LoginCommandResponse>>;
