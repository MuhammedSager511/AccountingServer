using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.Companies.DeleteCompanyById;
public sealed record DeleteCompanyByIdCommand(
    Guid Id) : IRequest<Result<string>>;
