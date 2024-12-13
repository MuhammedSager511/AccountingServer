using AccountingServer.Domain.ValueObjects;
using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.Companies.CreateCompany;
public sealed record CreateCompanyCommand(
    string Name,
    string FullAddress,
    string TaxDepartment,
    string TaxNumber,
    Database Database) : IRequest<Result<string>>;
