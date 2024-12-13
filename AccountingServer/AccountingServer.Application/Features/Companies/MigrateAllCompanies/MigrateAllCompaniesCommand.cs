using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.Companies.MigrateAllCompanies;
public sealed record MigrateAllCompaniesCommand() : IRequest<Result<string>>;
